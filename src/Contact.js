// src/Contact.js
import React from 'react';

const Contact = () => {
    return (
        <div className="container mx-auto p-4">
            <h1 className="text-3xl font-bold text-gray-800">Contact</h1>
            <p className="text-gray-600">Email: your.email@example.com</p>
            <p className="text-gray-600">LinkedIn: <a href="https://www.linkedin.com/in/yourprofile/" className="text-blue-500 hover:underline">Your LinkedIn Profile</a></p>
        </div>
    );
};

export default Contact;
