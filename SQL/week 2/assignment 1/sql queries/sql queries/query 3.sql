SELECT film.film_id, film.title, GROUP_CONCAT(film_actor.actor_id) AS actor_ids, COUNT(film_actor.actor_id) AS number_of_actors FROM film
INNER JOIN film_actor ON film.film_id = film_actor.film_id
GROUP BY film.film_id, film.title;