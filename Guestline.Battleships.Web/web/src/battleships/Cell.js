import './Battleships.css';
import React, { FC } from 'react';

interface CellProps {
  row: string;
  column: number;
}

const Cell : FC<CellProps> = ({ row, column }) => {
    const hit = () => {
        console.log(getIdentifier());
    };

    const getIdentifier = () => `"${String.fromCharCode(64 + column)}${row+1}"`

    return (
        <td className="cell" onClick={hit}>?</td>
    );
};

export default Cell;