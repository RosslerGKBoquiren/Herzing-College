-- List all the animals that have a father, a mother, and a race. We must know the parent’s race. (name, parents name, race name)
SELECT 
    animals.id,
    animals.name AS child_name,
    races.name AS child_race,
    animals.father_id,
    father.name AS father_name,
    father_race.name AS father_race,
    animals.mother_id,
    mother.name AS mother_name,
    mother_race.name AS mother_race
FROM animals
JOIN races ON animals.race_id = races.id
LEFT JOIN animals AS father ON animals.father_id = father.id
LEFT JOIN races AS father_race ON father.race_id = father_race.id
LEFT JOIN animals AS mother ON animals.mother_id = mother.id
LEFT JOIN races AS mother_race ON mother.race_id = mother_race.id
WHERE animals.father_id IS NOT NULL
    AND animals.mother_id IS NOT NULL;

