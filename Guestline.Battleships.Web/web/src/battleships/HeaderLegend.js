import './Battleships.css';
import React, { FC } from 'react';

const HeaderLegend : React.FC = () => {
  const columnLegend = Array.from({ length: 11 }, (_, index) => index);
  return (
    columnLegend.map((val) =>
        val === 0 
            ? (<td key={"empty"} className="cell-empty"></td>) 
            : (<td key={`"header-${val}"`} className="legend">{String.fromCharCode(64 + val)}</td>)
        )
  );
};

export default HeaderLegend;