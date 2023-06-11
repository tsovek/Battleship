import React, { useState, useEffect } from 'react';
import * as signalR from '@microsoft/signalr';

const ResultMessage : React.FC = () => {
    const [message, setMessage] = useState([]);
    useEffect(() => {
        setMessage("Click on any cell to hit!");
        const connection = new signalR.HubConnectionBuilder()
            .withUrl('/api/battleships/hubs/message')
            .build();

        connection.on('MessageUpdated', (message) => {
            setMessage(message);
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
        <p className="Result-message">{message}</p>
    );
};

export default ResultMessage;