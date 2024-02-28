SELECT COUNT(*) FROM inventory
WHERE film_id = (SELECT film_id FROM film WHERE title = 'Hunchback Impossible');