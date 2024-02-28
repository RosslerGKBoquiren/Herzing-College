SELECT film_id, title FROM film
WHERE language_id = (SELECT language_id FROM language WHERE name = 'English')
AND (title LIKE 'k%' OR title LIKE 'Q%');