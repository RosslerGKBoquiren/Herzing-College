-- List all the Cats who have parents (name and parent’s name)
SELECT animals.id, animals.name AS cat_name, animals.mother_id AS mother_id, mother.name AS mother_name, animals.father_id AS father_id, father.name AS father_name
FROM animals
JOIN animals mother ON animals.mother_id = mother.id AND mother.species_id = 2  -- Mother is a cat
JOIN animals father ON animals.father_id = father.id AND father.species_id = 2  -- Father is a cat
WHERE animals.species_id = 2 
	AND animals.mother_id IS NOT NULL 
    AND animals.father_id IS NOT NULL;
