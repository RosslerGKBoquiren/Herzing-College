-- 1- Update all the dog's nulled comments to "woff, woff, woff"
USE zoo;

UPDATE animals
SET comments = 'woff, woff, woff'
WHERE species_id = (SELECT id FROM species WHERE name = 'dog')
AND id IN (
    SELECT id
    FROM (
        SELECT id
        FROM animals
        WHERE comments IS NULL
    ) AS subquery
);

-- 2- List of animals (Name, Sex, DOB, Race_Id) whose race description has the word color in it.
SELECT name, sex, dob, race_id
FROM animals
WHERE race_id IN (SELECT id FROM races WHERE description LIKE '%color%');

-- 3- List of Bouli’s kid(s) (Name, Sex and DOB)
SELECT child.name, child.sex, child.dob, father.id AS father_id, father.name AS father_name
FROM zoo.animals AS child
JOIN zoo.animals AS father ON child.father_id = father.id
WHERE father.id = (SELECT id FROM zoo.animals WHERE name = 'Bouli');


-- 4- How many races exist in the animals table? (Display all of their names)
SELECT subquery.race_id, subquery.race_name, subquery.animal_count
FROM (
    SELECT races.id AS race_id, races.name AS race_name, COUNT(animals.id) AS animal_count
    FROM animals
    JOIN races ON animals.race_id = races.id
    GROUP BY races.id, races.name
) AS subquery;


-- 5- How many species exist in the races table? (Display all of their names)
SELECT subquery.species_count, subquery.species_names
FROM (
    SELECT COUNT(DISTINCT species_id) AS species_count, GROUP_CONCAT(DISTINCT species.current_name) AS species_names
    FROM races
    JOIN species ON races.species_id = species.id
) AS subquery;





