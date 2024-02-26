-- Data Retrieval with SELECT Statement:
SELECT column1, column2 
FROM table_name
WHERE condition;
-- the SELECT statement is fundamental for retrieving data
-- from one or more tables. You specify the columns you want
-- FROM specifies the table from which to retrieve
-- WHERE is the optional conditions to filter the results


-- Filtering and Sorting Data
SELECT column1, column2
FROM table_name
WHERE condition
ORDER BY column1 DESC;
-- WHERE for filtering
-- ORDER BY to sort the results
-- ASC / DESC control the sorting order ascending or descending

-- Aggregation functions
SELECT COUNT(*), AVG(salary), MAX(age)
FROM employees
WHERE department = 'IT';
-- Aggregate functions like COUNT, AVG, MAX and others allow you to perform
-- calculations on groups of rows, often used with the GROUP BY clause. 

-- Joins for combining tables
SELECT customers.customer_id, customers.customer_name, orders.order_date
FROM customers
JOIN orders ON customers.customer_id = orders.customer_id
-- JOIN combines rows from two or more tables based on related column. 
-- INNER JOIN, LEFT JOIN, RIGHT JOIN, and FULL JOIN are common types

-- Subqueries for nested queries
SELECT column1, column2
FOMR table_name
WHERE column3 IN (SELECT column3 FROM another_table WHERE condition);
-- Subqueries are queries nested within other queries. They can be used in SELECT
-- FROM, WHERE, and other clauses

-- Data modification with UPDATE, INSERT, DELETE:
UPDATE employees
SET salary = salary * 1.1
WHERE department = 'Finance';
-- UPDATE modifies existing records
-- INSERT adds new records
-- DELETE removedd records

-- Indexes and performance optimization:
CREATE INDEX indx_last_name ON employees(last_name);
-- Indexed improve query performance by allowing the database engine to quickly locate and retrive 
-- specific rows. Proper indexing is crucial for large datasets. 

-- Data Integrity and constrants
CREATE TABLE employee (
	employee_id INT PRIMARY KEY,
	employee_name VARCHAR(50) NOT NULL,
	department_id INT,
	FOREIGN KEY (department_id) REFERENCES department(department_id)
);
-- Contstrains enforce data integrity rules. Primary keys, foreigh keys, UNIQUE
-- constrains, and NOT NULL constrainss are common examples

-- Transcation and ACID properties
BEGIN TRANSACTION;
UPDATE accounts SET balance = balance - 100 WHERE account_id = 123;
INSERT INTO transactions (account_id, amount) VALUES (123, -100);
COMMIT;
-- Transactions ensure the atomicity, consistency, isolation, and durability
-- ACID of database operations. They either fully complete or fully roll back. 

-- Security and user management
CREATE USER 'username'@'localhost' IDENTIFIED BY 'password';
-- limit access to only necesssary privileges to enhance security
