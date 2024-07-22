// src/Projects.js
import React from 'react';

const Projects = () => {
    return (
        <div className="container mx-auto p-4">
            <h1 className="text-3xl font-bold text-gray-800 mb-4">Projects</h1>
            <ul className="space-y-4">
                <li className="bg-white p-4 rounded shadow">
                    <h2 className="text-2xl font-bold">Project 1</h2>
                    <p className="text-gray-600">Description of Project 1</p>
                    <a href="https://github.com/yourusername/project1" className="text-blue-500 hover:underline">GitHub Link</a>
                </li>
                <li className="bg-white p-4 rounded shadow">
                    <h2 className="text-2xl font-bold">Project 2</h2>
                    <p className="text-gray-600">Description of Project 2</p>
                    <a href="https://github.com/yourusername/project2" className="text-blue-500 hover:underline">GitHub Link</a>
                </li>
            </ul>
        </div>
    );
};

export default Projects;
