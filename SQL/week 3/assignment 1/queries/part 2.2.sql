-- List the female dogs who do not race and were born before July 2016. (name, dob, and race)
SELECT a.name, a.dob, COALESCE(r.name, 'No Race') AS race FROM animals a
LEFT JOIN races r ON a.race_id = r.id
WHERE a.species_id = 1
	AND a.sex = 'F'
	AND a.race_id IS NULL
	AND a.dob < '2016-07-01';
