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
('Room 101', 10),
('Room 102', 8),
('Room 103', 5),
('Room 104', 10),
('Room 105', 8);

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
SELECT id, CURDATE(), NULL, 'Active'
FROM Students;

-- 7. insert values Student_Invoice_Bills table
INSERT INTO Student_Invoice_Bills (student_id, balance, date, status)
SELECT id, 0, CURDATE(), '0'
FROM Students;

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
CREATE PROCEDURE add_class (
    IN program_name VARCHAR(100),
    IN classroom_id INT,
    OUT new_class_id INT
)
BEGIN
    DECLARE program_id INT;
    DECLARE max_capacity INT;
    DECLARE latest_start_date DATE;
    DECLARE new_start_date DATE;
    
    -- Get Program ID and max capacity
    SELECT id, max_capacity INTO program_id, max_capacity FROM Programs WHERE program_name = program_name LIMIT 1;
    
    -- Get latest start date for the program
    SELECT MAX(start_date) INTO latest_start_date FROM Classes WHERE program_id = program_id;
    
    -- Calculate new start date
    SET new_start_date = CASE
        WHEN latest_start_date IS NULL THEN
            CASE
                WHEN MONTH(CURDATE()) < 9 THEN DATE(CONCAT(YEAR(CURDATE()), '-09-01'))
                ELSE DATE(CONCAT(YEAR(CURDATE()) + 1, '-09-01'))
            END
        ELSE DATE_ADD(latest_start_date, INTERVAL 6 MONTH)
    END;

    -- Insert values into Classes table
    INSERT INTO Classes (classroom_id, program_id, start_date) VALUES (classroom_id, program_id, new_start_date);
    SET new_class_id = LAST_INSERT_ID();
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
