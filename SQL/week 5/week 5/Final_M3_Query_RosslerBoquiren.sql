-- 1. create database
CREATE DATABASE IF NOT EXISTS rosslerBoquiren_herzing_college;

-- 2. tables: ensure that each table is equipped with properties

USE rosslerBoquiren_herzing_college;

DROP TABLE IF EXISTS Programs, Classrooms, Classes, Students, Student_Profile, Student_Invoice_Bills;

-- Programs table
CREATE TABLE Programs (
id INT AUTO_INCREMENT PRIMARY KEY,
program_name VARCHAR(100) NOT NULL,
max_capacity INT NOT NULL,
duration INT NOT NULL, 
cost DECIMAL(10,2) NOT NULL
);

-- Classrooms table
CREATE TABLE Classrooms (
id INT AUTO_INCREMENT PRIMARY KEY,
room_number VARCHAR(20) NOT NULL,
capacity INT NOT NULL
);

-- Classes table
CREATE TABLE Classes (
id INT AUTO_INCREMENT PRIMARY KEY,
classroom_id INT,
program_id INT,
start_date DATE,
FOREIGN KEY (classroom_id) REFERENCES Classrooms(id) ON DELETE CASCADE ON UPDATE CASCADE,
FOREIGN KEY (program_id) REFERENCES Programs(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Students table
CREATE TABLE Students (
id INT AUTO_INCREMENT PRIMARY KEY,
first_name VARCHAR(50) NOT NULL,
last_name VARCHAR(50) NOT NULL,
DOB DATE NOT NULL,
address VARCHAR(100) NOT NULL,
phone VARCHAR(15) NOT NULL,
email VARCHAR(100) NOT NULL
);

-- Student_Profile table
CREATE TABLE Student_Profile (
id INT AUTO_INCREMENT PRIMARY KEY,
student_id INT,
enrolment_date DATE NOT NULL,
classes_id INT,
status ENUM('Active', 'Graduated', 'Suspended'),
FOREIGN KEY (student_id) REFERENCES Students(id) ON DELETE CASCADE ON UPDATE CASCADE,
FOREIGN KEY (classes_id) REFERENCES Classes(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Student_Invoice_Bills table
CREATE TABLE Student_Invoice_Bills (
id INT AUTO_INCREMENT PRIMARY KEY,
student_id INT,
balance DECIMAL(10,2) NOT NULL,
date DATE NOT NULL,
status ENUM('0', '1') NOT NULL,
FOREIGN KEY (student_id) REFERENCES Students(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- 3. insert values Programs table
INSERT INTO Programs (program_name, max_capacity, duration, cost)
VALUES 
('Programmer Analyst', 10, 15, 30000),
('Networking', 8, 24, 24000),
('Software Development', 5, 12, 12000);

-- 4. insert values Classrooms table
INSERT INTO Classrooms (room_number, capacity)
VALUES
('Room 110', 0),
('Room 108', 0),
('Room 105', 0),
('Room 210', 0),
('Room 208', 0);

-- 5. insert values Students table
INSERT INTO Students (first_name, last_name, DOB, address, phone, email)
VALUES
('Michael', 'Jordan', '1990-05-15', '123 Cavs St', '5141234567', 'jordan23@gmail.com'),
('Kobe', 'Bryant', '1991-06-18', '654 Lakers St', '5144567887', 'kobe08@gmail.com'),
('Steph', 'Curry', '1992-08-14', '789 Warriors St', '5143216554', 'steph30@gmail.com'),
('Jason', 'Tatum', '1993-07-22', '985 Celtics St', '5146541224', 'jason00@gmail.com'),
('Giannis', 'Antetokounmpo', '1994-01-21', '321 Bucks St', '5149874225', 'giannis34@gmail.com');

-- 6. insert values Student_Profile table
INSERT INTO Student_Profile (student_id, enrolment_date, classes_id, status)
VALUES
(1, '2024-03-02', 1, 'Active'),
(2, '2024-03-02', 2, 'Active'),
(3, '2024-03-05', 3, 'Active'),
(4, '2024-03-05', 4, 'Active'),
(5, '2024-03-08', 5, 'Active');

-- 7. insert values Student_Invoice_Bills table
INSERT INTO Student_Invoice_Bills (student_id, balance, date, status)
VALUES
(1, 30000.00, '2024-03-02', 1),
(2, 30000.00, '2024-03-02', 0),
(3, 24000.00, '2024-03-05', 0),
(4, 24000.00, '2024-03-05', 1),
(5, 12000.00, '2024-03-08', 0);

-- 8. insert values Classes table
INSERT INTO Classes (classroom_id, program_id, start_date)
VALUES
(1, 1, '2024-03-11'),
(2, 2, '2024-03-11'),
(3, 3, '2024-03-11'),
(1, 1, '2024-09-02'),
(2, 2, '2024-09-02');

-- stored procedure add new class
DROP PROCEDURE IF EXISTS add_class;
DELIMITER |
CREATE PROCEDURE add_class_with_capacity_check (
    IN program_name VARCHAR(100),
    IN room_number VARCHAR(20),
    IN class_start_date DATE
)
BEGIN
    DECLARE program_id INT;
    DECLARE classroom_id INT;
    DECLARE current_capacity INT;
    DECLARE max_capacity INT;

    -- Get the program ID based on the program name
    SELECT id INTO program_id FROM programs WHERE program_name = program_name;

    -- Get the classroom ID based on the room number
    SELECT id INTO classroom_id FROM classrooms WHERE room_number = room_number;

    -- Get the current capacity of the classroom
    SELECT COUNT(*) INTO current_capacity FROM classes WHERE classroom_id = classroom_id AND start_date = class_start_date;

    -- Get the maximum capacity of the classroom
    SELECT capacity INTO max_capacity FROM classrooms WHERE id = classroom_id;

    -- Check if the current capacity exceeds the maximum capacity
    IF current_capacity < max_capacity THEN
        -- Insert the new class
        INSERT INTO classes (classroom_id, program_id, start_date) VALUES (classroom_id, program_id, class_start_date);
        SELECT LAST_INSERT_ID() AS new_class_id; -- Return the ID of the newly inserted class
    ELSE
        -- Raise a custom error indicating that the maximum capacity of the classroom has been reached
        SIGNAL SQLSTATE 'ERROR' SET MESSAGE_TEXT = 'Maximum capacity of the classroom has been reached. Cannot add class.';
    END IF;
END |
    
-- stores procedure Delete Classes
DROP PROCEDURE IF EXISTS delete_class;
DELIMITER |
CREATE PROCEDURE delete_class (IN class_id INT)
BEGIN
    DELETE FROM Classes WHERE id = class_id;
END |


-- stored procedure display latest class
DROP PROCEDURE IF EXISTS display_latest_class;
DELIMITER |
CREATE PROCEDURE display_latest_class(IN program_name VARCHAR(100))
BEGIN
	SELECT *
    FROM Classes
    INNER JOIN Programs ON Classes.Program_id = Programs.id
    WHERE Programs.program_name = program_name
    ORDER BY Classes.start_date DESC
    LIMIT 1;
END |
