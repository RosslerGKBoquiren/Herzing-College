-- What query would you run to get the customer_id associated with all payments greater than twice the average payment amount? 
-- (HINT: use 2 * in your query to get twice the amount). 
-- Your result should include the customer id and the amount.
SELECT 
    payment.customer_id, payment.amount
FROM
    payment
WHERE
    payment.amount > 2 * (SELECT 
            AVG(amount)
        FROM
            payment);
