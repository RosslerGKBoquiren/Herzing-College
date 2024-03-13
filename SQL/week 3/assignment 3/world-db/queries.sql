-- What query would you run to list the first and last names of the 5 customers who have the highest number(count) of payments? 
USE sakila;

SELECT 
    customer.first_name,
    customer.last_name,
    COUNT(payment.payment_id) AS num_payments
FROM customer JOIN payment ON customer.customer_id = payment.customer_id
GROUP BY customer.customer_id
ORDER BY num_payments DESC
LIMIT 5;

-- What query would you run to get the customer_id associated with all payments greater than twice the average payment amount? 
-- (HINT: use 2 * in your query to get twice the amount). 
-- Your result should include the customer id and the amount.
SELECT payment.customer_id, payment.amount
FROM payment
WHERE payment.amount > 2 * (SELECT AVG(amount) FROM payment);

-- What is the distribution of animals based on their age categories? Categorize the animals into 'Young,' 'Adult,' and 'Senior'
USE zoo;

SELECT
    animals.id,
    species.current_name AS species,
    animals.name,
    YEAR(CURDATE()) - YEAR(animals.dob) AS current_age,
    animals.dob,
    animals.sex,
    CASE
        WHEN species.current_name = 'Turtle' AND (YEAR(CURDATE()) - YEAR(animals.dob)) <= 20 THEN 'Young'
        WHEN (YEAR(CURDATE()) - YEAR(animals.dob)) <= 7 THEN 'Young'
        WHEN (YEAR(CURDATE()) - YEAR(animals.dob)) BETWEEN 8 AND 9 THEN 'Adult'
        ELSE 'Senior'
    END AS age_category
FROM
    animals
LEFT JOIN
    species ON animals.species_id = species.id;
    

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
