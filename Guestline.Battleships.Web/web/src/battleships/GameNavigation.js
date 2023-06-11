import '../App.css';
import React, { FC } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';

const GameNavigation : React.FC = () => {

    const surrenderHandler = async () => {
        try {
            await axios.post('/api/battleships/game/surrender');
        } catch (error) {
            console.error('Error while giving up the game', error);
        }
    }
    return (
        <div className="Navigation">
            <Link to='/game/new'>
                <button type="button">New Game</button>
            </Link>
            <button type="button" onClick={surrenderHandler}>Surrender</button>
        </div>
    );
};

export default GameNavigation;