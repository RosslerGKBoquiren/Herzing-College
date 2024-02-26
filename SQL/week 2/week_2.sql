-- week 2

-- Querying multiple tables:
-- 1. Inner Join: returns rows when there is a match in both tables
-- INNER JOIN is used when you have related tables and want to retrieve data from both tables based on condition specified
SELECT *
FROM table1
INNER JOIN table2 ON table1.column = table2.column;

-- 2. LEFT JOIN: returns all rows from the left table and matching rows from the right table
SELECT *
FROM table1
LEFT JOIN table2 ON table1.column = table2.column;

-- 3. RIGHT JOIN: returns all rows from the right table and matching rows from the left table
SELECT *
FROM table1
RIGHT JOIN table2 ON table1.column = table2.column;

-- 4. FULL JOIN: returns all rows when there is a match in either table
-- FULL JOIN combines rows from two tables based on a condition but includes
-- unmatched rows from both tables 
SELECT *
FROM table1
FULL JOIN table2 ON table1.column = table2.column;


-- Working with sets
-- 1. UNION: Combines the result sets of two queries
SELECT column FROM table1
UNION
SELECT column FROM table2;

-- 2. INTERSECT: Returns common rows between two queries
-- INTERSECT is used with two separate queries and is not dependent on the structure of the tables
SELECT column FROM table1
INTERSECT
SELECT column FROM table2;

-- 3. EXCEPT: return rows from the first query that are not present in the second query
SELECT column FROM table1
EXCEPT
SELECT column FROM table2;


-- Data generation, manipulation and conversion
-- 1. Data generation: INSERT INTO to add new records to a table
INSERT INTO table_name (column1, column2, ...)
VALUES (value1, value2, ...);

-- 2. Manipulation: UPDATE modifies the existing records in a table
UPDATE table_name
SET column1 = value1, column2 = value2, ...
WHERE some_column = some_value;

-- 3. Conversion: CAST or CONVERT to change the data type of a column
SELECT CAST(column_name AS new_data_type) FROM table_name;



-- Grouping and Aggregates
-- 1. GROUP BY: groups rows based on the values in one or more columns
SELECT column1, COUNT(column2)
FROM table_name
GROUP BY column1;

-- 2. aggregate functions: COUNT, SUM, AVG, MIN, MAX
SELECT column1, AVG(column2)
FROM table_name
GROUP BY column1;

-- 3. HAVING: filters the results of a GROUP BY based on a specified condition
SELECT column1, AVG(column2)
FROM table_name
GROUP BY column1
HAVING AVG(column2) > 50;
