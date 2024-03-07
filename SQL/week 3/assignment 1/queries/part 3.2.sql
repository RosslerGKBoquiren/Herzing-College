-- List all Bouli’s kids (name, sex, and dob)
SELECT animals.id, animals.species, animals.name, animals.sex, animals.dob, animals.father_id, father.name AS father_name
FROM animals
JOIN species ON animals.species_id = species.id
LEFT JOIN animals AS father ON animals.father_id = father.id
WHERE species.current_name = 'Dog'
    AND animals.father_id = 22;





