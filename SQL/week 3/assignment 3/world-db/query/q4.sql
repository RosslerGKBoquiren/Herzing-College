-- What query would you run if your company wants to run an analysis on the country data of the world database to determine the size of the countries? 
USE world;

SELECT 
    Name AS Country,
    CASE
        WHEN Population < 100000 THEN 'Small'
        WHEN Population BETWEEN 100000 AND 500000 THEN 'Medium'
        ELSE 'Large'
    END AS Population_Size
FROM
    city;

