-- List of animals (Name, Sex, DOB, Race_Id) whose race description has the word color in it
SELECT animals.name, animals.sex, animals.dob, animals.race_id, races.description
FROM animals
JOIN races ON animals.race_id = races.id
WHERE LOWER(races.description) LIKE '%color%';
