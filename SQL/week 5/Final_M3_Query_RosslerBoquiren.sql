-- Ensure that database exists
CREATE DATABASE IF NOT EXISTS rosslerBoquiren_herzing_college;

-- Use the created database
USE rosslerBoquiren_herzing_college;

-- Drop existing tables if they exist
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

-- Add sample data into Programs table
INSERT INTO Programs (program_name, max_capacity, duration, cost)
VALUES 
('Programmer Analyst', 10, 15, 30000),
('Networking', 8, 24, 24000),
('Software Development', 5, 12, 12000);

-- Add sample data into Classrooms table
INSERT INTO Classrooms (room_number, capacity)
VALUES
(110, 2),
(108, 2),
(105, 1),
(210, 0),
(208, 0);

-- Add sample data into Students table
INSERT INTO Students (first_name, last_name, DOB, address, phone, email)
VALUES
('Michael', 'Jordan', '1990-05-15', '123 Cavs St', '5141234567', 'jordan23@gmail.com'),
('Kobe', 'Bryant', '1991-06-18', '654 Lakers St', '5144567887', 'kobe08@gmail.com'),
('Steph', 'Curry', '1992-08-14', '789 Warriors St', '5143216554', 'steph30@gmail.com'),
('Jason', 'Tatum', '1993-07-22', '985 Celtics St', '5146541224', 'jason00@gmail.com'),
('Giannis', 'Antetokounmpo', '1994-01-21', '321 Bucks St', '5149874225', 'giannis34@gmail.com');

-- Add sample data into Student_Profile table
INSERT INTO Student_Profile (student_id, enrolment_date, classes_id, status)
VALUES
(1, '2022-03-02', 1, 'Active'),
(2, '2022-03-02', 2, 'Active'),
(3, '2022-03-05', 3, 'Active'),
(4, '2022-03-05', 4, 'Active'),
(5, '2022-03-08', 5, 'Active');

-- Add sample data into Student_Invoice_Bills table
INSERT INTO Student_Invoice_Bills (student_id, balance, date, status)
VALUES
(1, 30000.00, '2022-03-02', 1),
(2, 30000.00, '2022-03-02', 0),
(3, 24000.00, '2022-03-05', 0),
(4, 24000.00, '2022-03-05', 1),
(5, 12000.00, '2022-03-08', 0);

-- Add sample data into Classes table
INSERT INTO Classes (classroom_id, program_id, start_date)
VALUES
(1, 1, '2022-03-14'),
(2, 2, '2022-03-14'),
(3, 3, '2022-03-14'),
(1, 1, '2022-09-05'),
(2, 2, '2022-09-05');

-- Add Classes Procedure
DROP PROCEDURE IF EXISTS add_classes;
DELIMITER |
CREATE PROCEDURE add_classes(
    IN input_program_name VARCHAR(100),
    IN input_room_number INT,
    OUT output_start_date DATE
)
BEGIN
    DECLARE store_program_id INT;
    DECLARE store_max_capacity INT;
    DECLARE classroom_capacity INT;

    -- Get program_id for the given program_name
    SELECT id, max_capacity INTO store_program_id, store_max_capacity FROM programs WHERE program_name = input_program_name;
    
    IF store_program_id IS NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Invalid program name';
    END IF;
    
    -- Get the next available start date for the program
    SET output_start_date = get_new_program_start_date(YEAR(CURDATE()), input_program_name);
    
    -- Check if the starting date is valid
    IF output_start_date IS NULL OR output_start_date < CURDATE() THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Invalid start date';
    END IF;
    
    -- Check if the specified classroom exists and has sufficient capacity
    SELECT capacity INTO classroom_capacity FROM classrooms WHERE room_number = input_room_number;
    
    IF classroom_capacity IS NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Invalid classroom number';
    END IF;
    
    IF classroom_capacity >= store_max_capacity THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Classroom is already at maximum capacity';
    END IF;

    -- Check if the starting date is after the latest class start date for the program
    IF EXISTS (
        SELECT 1
        FROM classes
        WHERE program_id = store_program_id
        AND start_date >= output_start_date
    ) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Invalid start date';
    END IF;
    
    -- Insert the new class into the classes table
    INSERT INTO classes (classroom_id, program_id, start_date)
    VALUES ((SELECT id FROM classrooms WHERE room_number = input_room_number), store_program_id, output_start_date);
END |





-- Delete Classes Procedure
DROP PROCEDURE IF EXISTS delete_classes;
DELIMITER |
CREATE PROCEDURE delete_classes(
    IN input_program_name VARCHAR(100)
)
BEGIN
    DECLARE store_program_id INT;
    DECLARE store_class_id INT;
    
    -- Get program_id for the given program_name
    SELECT id INTO store_program_id FROM programs WHERE program_name = input_program_name;
    
    IF store_program_id IS NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Invalid program name';
    END IF;
    
    -- Get the ID of the latest class for the program
    SELECT id INTO store_class_id
    FROM classes
    WHERE program_id = store_program_id
    ORDER BY start_date DESC
    LIMIT 1;
    
    -- Delete the latest class for the program
    DELETE FROM classes WHERE id = store_class_id;
END |


-- Add New Student Procedure
DROP PROCEDURE IF EXISTS add_new_student;
DELIMITER |
CREATE PROCEDURE add_new_student(
    IN input_first_name VARCHAR(100),
    IN input_last_name VARCHAR(100),
    IN input_dob DATE,
    IN input_address VARCHAR(255),
    IN input_phone VARCHAR(20),
    IN input_email VARCHAR(100),
    IN input_program_name VARCHAR(100)
)
BEGIN
    DECLARE store_program_id INT;
    DECLARE store_class_id INT;
    DECLARE store_student_id INT;
    DECLARE store_next_start_date DATE;
    DECLARE store_classroom_id INT;  -- Variable to store classroom_id
    
    -- Get program_id for the given program_name
    SELECT id INTO store_program_id FROM programs WHERE program_name = input_program_name;
    IF store_program_id IS NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Invalid program name';
    END IF;
    
    -- Calculate next start date for the program
    SET store_next_start_date = get_new_program_start_date(YEAR(CURDATE()), input_program_name);
    
    -- Check if space is available in the class for the program
    SELECT id, classroom_id INTO store_class_id, store_classroom_id
    FROM classes
    WHERE program_id = store_program_id
    AND start_date = store_next_start_date
    AND (SELECT COUNT(*) FROM student_profile WHERE classes_id = classes.id) < (SELECT max_capacity FROM programs WHERE id = store_program_id);
    
    IF store_class_id IS NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'No space available in the class for enrollment';
    END IF;
    
    -- Update the capacity of the classroom by incrementing by 1
    UPDATE classrooms SET capacity = capacity + 1 WHERE id = store_classroom_id;
    
    -- Add student to Students table
    INSERT INTO students (first_name, last_name, DOB, address, phone, email)
    VALUES (input_first_name, input_last_name, input_dob, input_address, input_phone, input_email);
    
    -- Get the student_id of the newly added student
    SELECT LAST_INSERT_ID() INTO store_student_id;
    
    -- Add student to Student_Profile table
    INSERT INTO student_profile (student_id, enrolment_date, classes_id, status)
    VALUES (store_student_id, store_next_start_date, store_class_id, 'Active');
END |



-- Edit Student Status Procedure
DROP PROCEDURE IF EXISTS edit_student_status;
DELIMITER |
CREATE PROCEDURE edit_student_status(
    IN input_student_id INT
)
BEGIN
    DECLARE balance_status INT;
    DECLARE program_duration INT;
    DECLARE class_start_date DATE;
    DECLARE current_date_var DATE;
    DECLARE student_status VARCHAR(20);

    -- Check if the student's balance status is paid
    SELECT status INTO balance_status
    FROM student_invoice_bills
    WHERE student_id = input_student_id
    ORDER BY date DESC
    LIMIT 1;

    -- Get program duration and class start date
    SELECT programs.duration, classes.start_date INTO program_duration, class_start_date
    FROM student_profile
    JOIN classes ON student_profile.classes_id = classes.id
    JOIN programs ON classes.program_id = programs.id
    WHERE student_profile.student_id = input_student_id;

    -- Get the current date
    SET current_date_var = CURDATE();

    -- Update student profile status based on balance status and program duration
    IF balance_status = 0 THEN
        -- Update status to 'Pending Balance'
        UPDATE student_profile
        SET status = 'Pending Balance'
        WHERE student_id = input_student_id;
    ELSE
        -- Check if program duration exceeds class start date compared to today's date
        IF program_duration >= DATEDIFF(current_date_var, class_start_date) THEN
            -- Update status to 'Graduated'
            UPDATE student_profile
            SET status = 'Graduated'
            WHERE student_id = input_student_id;
        END IF;
    END IF;
END |





-- Add Invoice Procedure
DROP PROCEDURE IF EXISTS add_invoice;
DELIMITER |
CREATE PROCEDURE add_invoice(
    IN input_student_id INT,
    IN input_balance DECIMAL(10,2),
    IN input_date DATE,
    IN input_status ENUM('0', '1')
)
BEGIN
    INSERT INTO student_invoice_bills (student_id, balance, date, status)
    VALUES (input_student_id, input_balance, input_date, input_status);
END |


-- Get Student Balance and Penalty Function
DROP FUNCTION IF EXISTS get_student_balance_and_penalty;
DELIMITER |
CREATE FUNCTION get_student_balance_and_penalty(input_student_id INT) RETURNS DECIMAL(10,2)
BEGIN
    DECLARE store_balance DECIMAL(10,2);
    DECLARE store_penalty DECIMAL(10,2);

    -- Calculate balance
    SELECT balance INTO store_balance
    FROM student_invoice_bills
    WHERE student_id = input_student_id;

    -- Calculate penalty
    IF store_balance > 0 THEN
        SET store_penalty = store_balance * 0.05; -- Assuming penalty is 5% of balance
    ELSE
        SET store_penalty = 0;
    END IF;

    RETURN store_balance + store_penalty;
END |

-- Add Penalties or Fees Procedure
DROP PROCEDURE IF EXISTS add_penalty_or_fee;
DELIMITER |
CREATE PROCEDURE add_penalty_or_fee(
    IN input_student_id INT,
    IN input_amount DECIMAL(10,2),
    IN input_status ENUM('0', '1')
)
BEGIN
    INSERT INTO student_invoice_bills (student_id, balance, date, status)
    VALUES (input_student_id, input_amount, CURDATE(), input_status);
END |



-- Add Program Procedure
DROP PROCEDURE IF EXISTS add_program;
DELIMITER |
CREATE PROCEDURE add_program(
    IN input_program_name VARCHAR(100),
    IN input_max_capacity INT,
    IN input_duration INT,
    IN input_cost DECIMAL(10,2)
)
BEGIN
    INSERT INTO programs (program_name, max_capacity, duration, cost)
    VALUES (input_program_name, input_max_capacity, input_duration, input_cost);
END |


-- Delete Program Procedure
DROP PROCEDURE IF EXISTS delete_program;
DELIMITER |
CREATE PROCEDURE delete_program(
    IN input_program_id INT
)
BEGIN
    DELETE FROM programs WHERE id = input_program_id;
END |


-- Add Classroom Procedure
DROP PROCEDURE IF EXISTS add_classroom;
DELIMITER |
CREATE PROCEDURE add_classroom(
    IN input_room_number VARCHAR(20),
    IN input_capacity INT
)
BEGIN
    INSERT INTO classrooms (room_number, capacity)
    VALUES (input_room_number, input_capacity);
END |


-- Delete Classroom Procedure
DROP PROCEDURE IF EXISTS delete_classroom;
DELIMITER |
CREATE PROCEDURE delete_classroom(
    IN input_classroom_id INT
)
BEGIN
    DELETE FROM classrooms WHERE id = input_classroom_id;
END |


