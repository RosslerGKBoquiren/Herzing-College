// src/NavBar.js
import React from 'react';
import { Link } from 'react-router-dom';

const NavBar = () => {
    return (
        <nav className="bg-gray-800 p-4">
            <ul className="flex justify-around">
                <li><Link to="/" className="text-white hover:text-gray-400">Home</Link></li>
                <li><Link to="/projects" className="text-white hover:text-gray-400">Projects</Link></li>
                <li><Link to="/resume" className="text-white hover:text-gray-400">Resume</Link></li>
                <li><Link to="/contact" className="text-white hover:text-gray-400">Contact</Link></li>
            </ul>
        </nav>
    );
};

export default NavBar;

