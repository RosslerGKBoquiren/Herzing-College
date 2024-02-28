SELECT film.film_id, film.title, COUNT(rental.rental_id) AS rental_count FROM film
JOIN inventory ON film.film_id = inventory.film_id
JOIN rental ON inventory.inventory_id = rental.inventory_id
GROUP BY film.film_id, film.title
ORDER BY rental_count DESC;