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

-- Stored procedure to add a new class
DROP PROCEDURE IF EXISTS add_class;
DELIMITER |
CREATE PROCEDURE add_class(IN program_name_param VARCHAR(100))
BEGIN
    DECLARE program_id_param INT;
    DECLARE max_capacity_param INT;
    DECLARE room_number_param VARCHAR(20);
    DECLARE start_date_param DATE;
    
    -- Get the program_id for the given program_name
    SELECT id, max_capacity INTO program_id_param, max_capacity_param 
    FROM programs 
    WHERE program_name = program_name_param;
    
    -- Get the room_number based on the maximum capacity of the program
    SET room_number_param = CONCAT('Room ', max_capacity_param);
    
    -- Calculate the start_date
    SET start_date_param = (
        SELECT 
            CASE
                WHEN MONTH(CURDATE()) >= 9 THEN 
                    DATE_ADD(DATE(CONCAT(YEAR(CURDATE()) + 1, '-03-01')), INTERVAL (14 - WEEKDAY(DATE(CONCAT(YEAR(CURDATE()) + 1, '-03-01')))) DAY)
                ELSE 
                    DATE_ADD(DATE(CONCAT(YEAR(CURDATE()), '-09-01')), INTERVAL (14 - WEEKDAY(DATE(CONCAT(YEAR(CURDATE()), '-09-01')))) DAY)
            END
    );
    
    -- Insert the new class into the classes table
    INSERT INTO classes (classroom_id, program_id, start_date) 
    VALUES ((SELECT id FROM classrooms WHERE room_number = room_number_param), program_id_param, start_date_param);
    
END |

-- Stored procedure to get the next start date for a program
DROP PROCEDURE IF EXISTS next_start_date;
DELIMITER |
CREATE PROCEDURE next_start_date(IN program_name VARCHAR(100), OUT next_start_date DATE)
BEGIN
    -- Get the current date
    SET @current_date := CURDATE();
    
    -- Get the next year
    SET @next_year := YEAR(CURDATE()) + 1;
    
    -- Calculate the next start date for the program
    SELECT 
        CASE
            WHEN MONTH(@current_date) >= 9 THEN DATE_ADD(DATE(CONCAT(@next_year, '-03-01')), INTERVAL (14 - WEEKDAY(DATE(CONCAT(@next_year, '-03-01')))) DAY)
            ELSE DATE_ADD(DATE(CONCAT(YEAR(@current_date), '-09-01')), INTERVAL (14 - WEEKDAY(DATE(CONCAT(YEAR(@current_date), '-09-01')))) DAY)
        END
    INTO next_start_date;
END |

-- Stored function to calculate and return the start date for a new program
DROP FUNCTION IF EXISTS calculate_new_date;
DELIMITER |
CREATE FUNCTION calculate_new_date(program_year INT, program_name VARCHAR(100)) RETURNS DATE
BEGIN
    DECLARE next_start_date DATE;
    
    -- Calculate the new start date for the program
    SELECT 
        CASE
            WHEN MONTH(CURDATE()) >= 9 THEN DATE_ADD(DATE(CONCAT(program_year, '-03-01')), INTERVAL (14 - WEEKDAY(DATE(CONCAT(program_year, '-03-01')))) DAY)
            ELSE DATE_ADD(DATE(CONCAT(program_year - 1, '-09-01')), INTERVAL (14 - WEEKDAY(DATE(CONCAT(program_year - 1, '-09-01')))) DAY)
        END
    INTO next_start_date;
    
    RETURN next_start_date;
END |


-- Stored procedure to delete classes if needed
DROP PROCEDURE IF EXISTS delete_class;
DELIMITER |
CREATE PROCEDURE delete_class(IN program_name VARCHAR(100))
BEGIN
    DECLARE program_id INT;
    DECLARE next_start_date DATE;
    
    -- Get the program_id for the given program_name
    SELECT id INTO program_id 
    FROM programs 
    WHERE program_name = program_name
    ORDER BY created_date DESC
    LIMIT 1; -- Select only the latest program
    
    -- Calculate the next start date for the program
    SET next_start_date = calculate_new_date(YEAR(CURDATE()), program_name);
    
    -- Delete classes if the start date of the program is after today's date
    DELETE FROM classes WHERE program_id = program_id AND start_date > next_start_date;
END |
