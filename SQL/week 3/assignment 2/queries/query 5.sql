-- How many species exist in the races table? (Display all of their names)
SELECT COUNT(DISTINCT species_id) AS species_count, GROUP_CONCAT(DISTINCT species.current_name) AS species_names
FROM races
JOIN species ON races.species_id = species.id;

