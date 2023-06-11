import './Battleships.css';
import React, { useEffect, useState } from 'react';
import Cell from './Cell.js'
import HeaderLegend from './HeaderLegend.js'

const Grid : React.FC = () => {   
    const [cells, setCells] = useState([]);
    useEffect(() => {
        const initialCells = []
        for (let i = 0; i < 10; i++) {
            initialCells[i] = [];
            for (let j = 0; j < 10; j++) {
                initialCells[i][j] = 0;
            }
        }
        setCells(initialCells);
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
                  <Cell key={`${i}${j}`} row={i} column={j} />
                ))}
              </tr>
            ))}
        </tbody>
       </table>
    );
}

export default Grid;