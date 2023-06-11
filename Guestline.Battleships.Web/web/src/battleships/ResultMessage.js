import React, { useState } from 'react';

const ResultMessage : React.FC = () => {
    const [message, setMessage] = useState([]);
    return (
        <p className="Result-message">{message}</p>
    );
};

export default ResultMessage;