import './Battleships.css';
import React, { FC } from 'react';
import axios from 'axios';

interface CellProps {
  row: string;
  column: number;
  value: string
}

const Cell : FC<CellProps> = ({ row, column, value }) => {
    const hit = async () => {
        try {
            let cellId = getIdentifier();
            var res = await axios.post('/api/battleships/game/hit/' + cellId);
        } catch (error) {
            console.error('Error fetching data:', error);
        }
    };

    const getIdentifier = () => String.fromCharCode(65 + column) + (row+1);

    const resultMap = new Map([
        ['Unknown', ' '],
        ['Miss', 'X'],
        ['Hit', 'O'],
        ['Hit and sunk', 'Ø']
    ]); 

    return (
        <td className="cell" onClick={hit}>{resultMap.get(value)}</td>
    );
};

export default Cell;