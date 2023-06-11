import React from 'react';
import Grid from '../battleships/Grid.js'
import ResultMessage from '../battleships/ResultMessage.js'

const Game : React.FC = () => {
    return (
        <div>
            <ResultMessage />
            <Grid />
        </div>
    );
};

export default Game;