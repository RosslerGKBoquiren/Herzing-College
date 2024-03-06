-- List all the 'American Bully'
SELECT animals.*, races.name AS race_name
FROM animals
JOIN races ON animals.race_id = races.id
WHERE races.name = 'American Bully';



