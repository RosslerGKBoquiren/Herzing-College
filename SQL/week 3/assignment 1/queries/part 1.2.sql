-- List all the animals (name, dob, race) who don’t have the word color in their race description.
SELECT animals.name, animals.dob, races.name AS race, races.description AS race_description FROM animals
JOIN races ON animals.race_id = races.id
WHERE LOWER(races.description) NOT LIKE '%color%';
