SELECT film_id, title, description, length, rating FROM film
WHERE description LIKE '%story%' AND description LIKE '%dog%'
ORDER BY length;