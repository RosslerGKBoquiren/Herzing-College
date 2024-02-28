SELECT customer.customer_id, customer.last_name, SUM(payment.amount) AS total_paid FROM customer
JOIN payment ON customer.customer_id = payment.customer_id
GROUP BY customer.customer_id, customer.last_name, customer.first_name
ORDER BY customer.last_name, customer.first_name;