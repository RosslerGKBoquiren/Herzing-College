// src/Resume.js
import React from 'react';

const Resume = () => {
    return (
        <div className="container mx-auto p-4">
            <h1 className="text-3xl font-bold text-gray-800">Rossler Gian Karlo Boquiren</h1>
            <p className="text-gray-600">Montreal QC H3S1R7 | (C) 514 691 0806 | <a href="mailto:5276151@mtl.herzing.ca" className="text-blue-500 hover:underline">5276151@mtl.herzing.ca</a></p>

            <h2 className="text-2xl font-bold mt-4">Objective</h2>
            <p className="text-gray-600">
                My objective is to obtain a position as a software developer where my technical skills and experience can be utilized in contributing to the development of high-quality projects. My goal is to work collaboratively with a team to produce clean codes and provide support in all aspects of the process.
            </p>

            <h2 className="text-2xl font-bold mt-4">Technical Skills</h2>
            <ul className="list-disc list-inside text-gray-600">
                <li>HTML, CSS, JavaScript, Python, SQL, PHP, C#.NET</li>
                <li>Microsoft Office Word, Excel, PowerPoint</li>
                <li>AutoCAD software, SketchUp 3D Modeling software, and Revit</li>
            </ul>

            <h2 className="text-2xl font-bold mt-4">Education</h2>
            <p className="text-gray-600">
                <strong>HERZING COLLEGE</strong>, Montreal QC<br />
                AEC Diploma Software Development
            </p>
            <p className="text-gray-600">
                AEC Diploma Technical Sustainable Architecture
            </p>
            <p className="text-gray-600">
                <strong>VANIER COLLEGE</strong>, Montreal QC<br />
                AEC Certification Vanier College Financial Security Advisor
            </p>
            <p className="text-gray-600">
                DEC Vanier College Accounting Management
            </p>

            <h2 className="text-2xl font-bold mt-4">Language</h2>
            <p className="text-gray-600">English, French, Tagalog</p>

            <h2 className="text-2xl font-bold mt-4">Work Experience</h2>
            <p className="text-gray-600">
                <strong>Station Attendant</strong>, 2022 to 2023<br />
                Air Canada YUL Dorval QC
            </p>
            <ul className="list-disc list-inside text-gray-600">
                <li>Coordinated ground crew activities to complete objectives on schedule</li>
                <li>Reported equipment malfunctions to supervisor for immediate repair attention to avoid creating flight departure delays</li>
                <li>Safely operated various types of equipment such as conveyor belts, tractors, and tugs</li>
                <li>Assisted in training junior station attendants on the job</li>
            </ul>

            <p className="text-gray-600">
                <strong>Financial Security Advisor</strong>, 2016 to Present<br />
                World Financial Group Insurance Agency of Canada Montreal QC
            </p>
            <ul className="list-disc list-inside text-gray-600">
                <li>Achieved $50,000 in sales commission within the first 2 years</li>
                <li>Taught advanced training techniques for recent sales agents</li>
                <li>Promoted to Marketing Director in 2018</li>
                <li>Created financial strategies using financial products to help clients reach stability during life events including retirement</li>
            </ul>

            <p className="text-gray-600">
                <strong>Customer Service Representative</strong>, 2015 to 2017<br />
                Insta-Cheques St Laurent QC
            </p>
            <ul className="list-disc list-inside text-gray-600">
                <li>Reached store quarterly sales goals making our location the most profitable in Montreal</li>
                <li>Developed scheduling strategies with the manager to keep budget limits</li>
                <li>Enhanced bad-debt collection strategies to improve collection ratings</li>
            </ul>

            <p className="text-gray-600">
                <strong>Assistant Manager</strong>, 2013 to 2014<br />
                St Hubert - Pierrefonds QC
            </p>
            <ul className="list-disc list-inside text-gray-600">
                <li>Managed and trained kitchen staff to build a team</li>
                <li>Developed a daily to-do-list for each of the restaurants departments to heighten inspection results</li>
                <li>Handled guest complaints and properly reasoned with them to keep loyal and new clients</li>
            </ul>
        </div>
    );
};

export default Resume;
