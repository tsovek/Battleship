﻿import './Home.css';
import React from 'react'
import { Link } from 'react-router-dom';

function Home() {
  return (
     <div className="Navigation">
        <Link to='/game/new'>
            <button type="button">New Game</button>
        </Link>
        <Link to='/game'>
            <button type="button">Continue</button>
        </Link>
     </div>
  );
}

export default Home;