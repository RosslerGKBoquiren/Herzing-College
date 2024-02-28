SELECT actor.actor_id, actor.first_name, actor.last_name FROM actor
WHERE actor.actor_id 
IN (SELECT film_actor.actor_id FROM film_actor JOIN film ON film_actor.film_id = film.film_id WHERE film.title = 'Alone Trip');