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


