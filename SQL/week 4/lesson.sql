CREATE DATABASE zoo_2;

DROP PROCEDURE IF EXISTS show_animal_race;
DELIMITER |
CREATE PROCEDURE show_animal_race()
BEGIN
	SELECT animals.id, animals.name, animals.sex, animals.dob, races.name
    FROM animals
    LEFT JOIN races
    ON animals.race_id = races.id;
END |

DELIMITER |
CALL show_animal_race;

DROP PROCEDURE IF EXISTS show_race_by_species;

DELIMITER |
CREATE PROCEDURE show_race_by_species(IN in_species_id INT)
BEGIN 
    SELECT races.id, races.description, races.price, species.current_name
    FROM races
    LEFT JOIN species
    ON races.species_id = species.id
    WHERE races.species_id = in_species_id;
END |

CALL show_race_by_species(2);

DROP PROCEDURE IF EXISTS calculate_price;

DELIMITER |
CREATE PROCEDURE calculate_price(IN in_animal_id INT, OUT put_price DECIMAL(7,2))
BEGIN
	SELECT COALESCE(races.price, species.price) INTO put_price
    FROM animals
    LEFT JOIN races
    ON animals.race_id = races.id
    LEFT JOIN species
    ON animals.species_id = species.id
    WHERE animals.id = in_animal_id;
END |

CALL calculate_price(12, @price);
SELECT @price;
