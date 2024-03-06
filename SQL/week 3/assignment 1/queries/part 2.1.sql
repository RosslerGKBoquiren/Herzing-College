-- List all the Cats and Parrots with their sex, species, Latin name, and race if exist. Order by animal type and race
SELECT  animals.name, animals.sex, species.current_name AS species, species.latin_name, COALESCE(races.name, 'No Race') AS race
FROM animals 
JOIN species ON animals.species_id = species.id 
LEFT JOIN races ON animals.race_id = races.id 
WHERE species.current_name IN ('Cat', 'Parrot') 
ORDER BY species.current_name, race;

