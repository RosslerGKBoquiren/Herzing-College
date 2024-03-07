-- List of Bouli’s kid(s) (Name, Sex and DOB)
SELECT animals.id, animals.name AS child_name, animals.sex, animals.dob, animals.species, animals.father_id, father.name AS father_name
FROM animals
LEFT JOIN animals AS father ON animals.father_id = father.id
WHERE animals.father_id = (SELECT id FROM animals WHERE name = 'Bouli');


