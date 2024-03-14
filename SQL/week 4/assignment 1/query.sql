-- 1. Build a query and save it as a view that displays all rentals, 
-- with the surname of the customer and of the employee who gave the film and the store to which the employee belongs, assigning- to each field a nickname.
CREATE OR REPLACE VIEW view_display_rentals AS
SELECT 
    rental.rental_id,
    customer.last_name AS customer_last_name,
    staff.last_name AS staff_last_name,
    staff.store_id AS staff_store_id
FROM rental
JOIN customer ON rental.customer_id = customer.customer_id
LEFT JOIN staff ON rental.staff_id = staff.staff_id;


-- 2. Then build another query that takes data from this view (so not from the original tables, thus use the nicknames) 
-- and joining it with table employees again, display also the surname of the responsible for the store, everything sorted by 
-- employee’s surname
SELECT 
    view_display_rentals.rental_id,
    view_display_rentals.customer_last_name,
    view_display_rentals.staff_store_id,
    staff.last_name AS store_manager_last_name
FROM view_display_rentals
LEFT JOIN staff ON view_display_rentals.staff_store_id = staff.store_id;
    
-- 3. Generate a multicolumn index on the payment table that could be used by both
CREATE INDEX multicolumn_index ON payment(customer_id, payment_date, amount);

-- 4. 4.	The film rental company manager would like to have a report that includes the name of every country, 
-- along with the total payments for all customers who live in each country. Generate a view definition that queries 
-- the country table and uses a scalar subquery to calculate a value for a column named tot_payments.
CREATE OR REPLACE VIEW country_payments_report AS
SELECT country.country_id, country.country,
    ( SELECT SUM(payment.amount) FROM payment
            JOIN customer ON payment.customer_id = customer.customer_id
            JOIN address ON customer.address_id = address.address_id
            JOIN city ON address.city_id = city.city_id
        WHERE city.country_id = country.country_id
    ) AS tot_payments
FROM country;

-- 5. Write a query that lists all of the indexes in the Sakila schema. Include the table names.
SELECT table_name, index_name
FROM information_schema.statistics
WHERE table_schema = 'sakila';

-- 6.	Write a query that generates output that can be used to create all of the indexes on the sakila.customer table. 
-- Output should be of the form: "ALTER TABLE <table_name> ADD INDEX <index_name> (<column_list>)"
SELECT 
    CONCAT('ALTER TABLE sakila.customer ADD INDEX ', 
    index_name, 
    ' (', GROUP_CONCAT(column_name ORDER BY seq_in_index), ');') AS generate_query
FROM information_schema.statistics
WHERE table_schema = 'sakila' AND table_name = 'customer'
GROUP BY index_name;
















