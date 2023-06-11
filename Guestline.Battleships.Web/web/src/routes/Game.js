import React from 'react';
import Grid from '../battleships/Grid.js'
import ResultMessage from '../battleships/ResultMessage.js'
import GameNavigation from '../battleships/GameNavigation.js'

const Game : React.FC = () => {
    return (
        <div>
            <GameNavigation />
            <ResultMessage />
            <Grid />
        </div>
    );
};

export default Game;