-- What query would you run to list the first and last names of the 5 customers who have the highest number(count) of payments? 
USE sakila;

SELECT 
    customer.first_name,
    customer.last_name,
    COUNT(payment.payment_id) AS num_payments
FROM
    customer
        JOIN
    payment ON customer.customer_id = payment.customer_id
GROUP BY customer.customer_id
ORDER BY num_payments DESC
LIMIT 5;



