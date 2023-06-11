import React, { useEffect } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const NewGame : React.FC = () => {
    const history = useNavigate();

    useEffect(() => {
        const initNewGame = async () => {
            try {
                await axios.post('/api/battleships/game/new');
                history('/game');
            } catch (error) {
                console.error('Error creating new game', error);
            }
        };
        initNewGame();
    }, []);

    return (
        <div>Initializing new game...</div>
    );
};

export default NewGame;