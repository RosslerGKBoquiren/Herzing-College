-- What is the distribution of animals based on their age categories? Categorize the animals into 'Young,' 'Adult,' and 'Senior'
SELECT
    animals.id,
    species.current_name AS species,
    animals.name,
    YEAR(CURDATE()) - YEAR(animals.dob) AS current_age,
    animals.dob,
    animals.sex,
    CASE
        WHEN species.current_name = 'Turtle' AND (YEAR(CURDATE()) - YEAR(animals.dob)) <= 20 THEN 'Young'
        WHEN (YEAR(CURDATE()) - YEAR(animals.dob)) <= 7 THEN 'Young'
        WHEN (YEAR(CURDATE()) - YEAR(animals.dob)) BETWEEN 8 AND 9 THEN 'Adult'
        ELSE 'Senior'
    END AS age_category
FROM
    animals
LEFT JOIN
    species ON animals.species_id = species.id;




