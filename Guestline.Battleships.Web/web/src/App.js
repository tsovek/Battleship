import './App.css';
import Game from './routes/Game.js'
import NewGame from './routes/NewGame.js'
import Home from './routes/Home.js'
import Layout from './routes/Layout.js'
import React from 'react'
import { BrowserRouter, Routes, Route } from 'react-router-dom';

function App() {  
  return (
      <BrowserRouter>
        <div className="App">
           <header className="App-header">
             <Routes>
               <Route path="/" element={<Layout />} />
               <Route index element={<Home />} />
               <Route path="/game" element={<Game />} />
               <Route path="/game/new" element={<NewGame />} />
             </Routes>
           </header>
        </div>
      </BrowserRouter>
  );
}

export default App;
