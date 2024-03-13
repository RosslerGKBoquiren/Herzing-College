-- Part 1
-- List all the 'American Bully'
SELECT animals.*, races.name AS race_name
FROM animals
JOIN races ON animals.race_id = races.id
WHERE races.name = 'American Bully';

-- List all the animals (name, dob, race) who don’t have the word color in their race description.
SELECT animals.name, animals.dob, races.name AS race, races.description AS race_description FROM animals
JOIN races ON animals.race_id = races.id
WHERE LOWER(races.description) NOT LIKE '%color%';

-- Part 2
-- List all the Cats and Parrots with their sex, species, Latin name, and race if exist. Order by animal type and race
SELECT  animals.name, animals.sex, species.current_name AS species, species.latin_name, COALESCE(races.name, 'No Race') AS race
FROM animals 
JOIN species ON animals.species_id = species.id 
LEFT JOIN races ON animals.race_id = races.id 
WHERE species.current_name IN ('Cat', 'Parrot') 
ORDER BY species.current_name, race;

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
    
-- Part 3
-- List all the Cats who have parents (name and parent’s name)
SELECT 
    animals.id,
    animals.species AS species,
    animals.name AS cat_name,
    mother.name AS mother_name,
    father.name AS father_name
FROM animals
JOIN animals mother ON animals.mother_id = mother.id AND mother.species_id = 2  -- Mother is a cat
JOIN animals father ON animals.father_id = father.id AND father.species_id = 2  -- Father is a cat
WHERE animals.species_id = 2;

-- List all Bouli’s kids (name, sex, and dob)
SELECT animals.id, animals.species, animals.name, animals.sex, animals.dob, animals.father_id, father.name AS father_name
FROM animals
JOIN species ON animals.species_id = species.id
LEFT JOIN animals AS father ON animals.father_id = father.id
WHERE species.current_name = 'Dog'
    AND animals.father_id = 22;

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