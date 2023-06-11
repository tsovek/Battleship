import './Battleships.css';
import React, { useEffect, useState } from 'react';
import * as signalR from '@microsoft/signalr';
import Cell from './Cell.js'
import HeaderLegend from './HeaderLegend.js'

const Grid : React.FC = () => { 
    const [cells, setCells] = useState([]);
    useEffect(() => {
        const initialCells = []
        for (let i = 0; i < 10; i++) {
            initialCells[i] = [];
            for (let j = 0; j < 10; j++) {
                initialCells[i][j] = 'Unknown';
            }
        }
        setCells(initialCells);

        const connection = new signalR.HubConnectionBuilder()
            .withUrl('/api/battleships/hubs/board')
            .build();

        connection.on('BoardUpdated', (board) => {
            let array = [];
            try {
                let dto = JSON.parse(board);
                dto.Items.forEach(item => {
                    if (!array[item.Row]) {
                        array[item.Row] = [];
                    }
                    array[item.Row][item.Column] = item.Value;
                });
                setCells(array);
            } catch (error) {
                console.log(error);
            }
        });

        connection.start()
            .then(() => {
                console.log('SignalR connection established.');
            })
            .catch(error => {
                console.error('Error establishing SignalR connection:', error);
            });

        return () => {
            connection.stop();
        };
    }, []);

    return (
      <table>
        <tbody>
          <tr key={0}>
            <HeaderLegend />
          </tr>
          {cells.map((row, i) => (
              <tr key={i+1}>
                <td key={`"legend-${i+1}"`} className="legend">{i+1}</td>
                {row.map((col, j) => (
                  <Cell key={`${i}${j}`} row={i} column={j} value={col} />
                ))}
              </tr>
            ))}
        </tbody>
       </table>
    );
}

export default Grid;