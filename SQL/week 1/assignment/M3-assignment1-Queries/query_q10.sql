SELECT film_id, title, description, length, rating FROM film
WHERE description LIKE '%thrilling%' AND description LIKE '%shark%'
ORDER BY length DESC
LIMIT 1;