-- List the female dogs who do not race and were born before July 2016. (name, dob, and race)
SELECT 
    animals.name,
    animals.dob,
    animals.sex,
    species.current_name AS species,
    COALESCE(races.name, 'No Race') AS race
FROM animals
LEFT JOIN races ON animals.race_id = races.id
JOIN species ON animals.species_id = species.id
WHERE animals.species_id = 1
    AND animals.sex = 'F'
    AND animals.race_id IS NULL
    AND animals.dob < '2016-07-01';
