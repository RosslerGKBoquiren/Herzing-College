How many races exist in the animals table? (Display all of their names)
SELECT races.id AS race_id, races.name AS race_name, COUNT(animals.id) AS animal_count
FROM animals
JOIN races ON animals.race_id = races.id
GROUP BY races.id, races.name;

