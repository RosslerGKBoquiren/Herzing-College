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

DROP FUNCTION IF EXISTS test_function;

DELIMITER | 
-- FUNCTIONS
CREATE FUNCTION test_function() RETURNS VARCHAR(50)
BEGIN 
	RETURN 'Herzing College Montreal';
END |

DROP FUNCTION IF EXISTS count_species;
DELIMITER |
CREATE FUNCTION count_species(s_id INT) RETURNS INT(7)
BEGIN
	DECLARE num INT(7);
    SELECT COUNT(*) INTO num
    FROM animals
    WHERE species_id = s_id;
    RETURN num;
END |

SELECT count_species(1) number_of_dog |
SELECT test_function() School |

SELECT 
	species_id 'Species ID', 
    GROUP_CONCAT(id) 'Animal IDs', 
    group_concat(name) 'Animal Names', 
    count_species(species_id) 'Number of Animals' 
FROM animals 
GROUP BY species_id;
	

DROP FUNCTION IF EXISTS get_species_name;

DELIMITER |
CREATE FUNCTION get_species_name(s_id INT) RETURNS VARCHAR(50)
BEGIN
	DECLARE s_name VARCHAR(50);
    
    SELECT current_name INTO s_name
    FROM species
    WHERE id = s_id;
    
    RETURN s_name;
END |

SELECT name, dob, sex, get_species_name(species_id) Specie
FROM animals
WHERE id = 1 |

DROP FUNCTION IF EXISTS get_mother_name;
DELIMITER |
CREATE FUNCTION get_mother_name(a_id INT) RETURNS VARCHAR(50)
BEGIN
	DECLARE m_name VARCHAR(50);
    SELECT COALESCE(m.name, 'No Mommy') INTO m_name
    FROM animals c
    LEFT JOIN animals m
    ON c.mother_id = m.id
    WHERE c.id = a_id;
    RETURN m_name;
END |

SELECT id, name, sex, dob, get_species_name(id) Specie, get_mother_name(id) Mom
FROM animals |
-- WHERE id = 25

DROP PROCEDURE IF EXISTS display_animal;
DELIMITER | 
CREATE PROCEDURE display_animal()
BEGIN
	SELECT id, name, dob, get_mother_name(id)
    FROM animals;
END |

DROP FUNCTION IF EXISTS count_up_to;
DELIMITER |
CREATE FUNCTION count_up_to(num INT) RETURNS TEXT
BEGIN
	DECLARE counter INT DEFAULT 0;
    DECLARE result TEXT DEFAULT '';
    WHILE counter <= num DO
		SET result = CONCAT(result, counter, '. ');
        SET counter = counter + 1;
	END WHILE;
    RETURN TRIM(TRAILING ', ' FROM result);
END |

DROP FUNCTION IF EXISTS count_funny;
DELIMITER | 
CREATE FUNCTION count_funny(x INT) RETURNS TEXT
BEGIN
	DECLARE result TEXT DEFAULT '';
    DECLARE i INT DEFAULT 0;
    
    WHILE i <= x DO
		SET result = CONCAT(result, i);
        IF i % 5 = 0 THEN
			SET result = CONCAT(result, ' <- funny');
		END IF;
        SET result = CONCAT(result, '\n');
        SET i = i + 1;
	END WHILE;
    
    RETURN results;
END |

-- generate a list of days at intervals of two days, starting from the current day (DAY(NOW())) up to a specified number of days (num)
DROP FUNCTION IF EXISTS Every_two_days;
DELIMITER |
CREATE FUNCTION Every_two_days(num INT) RETURNS TEXT
BEGIN
	DECLARE i INT DEFAULT 0;
    DECLARE output TEXT DEFAULT '';
    SET i = DAY(NOW());
    SET output = i;
		REPEAT
			IF i = DAY(NOW()) THEN
            SET output = CONCAT_WS(output, i);
            ELSE
            SET output = CONCAT_WS(',', output, i);
            END IF;
            SET I = i + 2;
		UNTIL i > num END REPEAT;
        RETURN output;
	END |
    
    SELECT Every_two_days(30) 'RESULT'
    
    -- TRIGGERS
    
    DROP TRIGGER IF EXISTS test;
    DELIMITER |
    -- automatically update the 'current_name' field in the 'species' table whenever an update operation is performed on the 'animals' tabls
    CREATE TRIGGER test BEFORE UPDATE ON animals FOR EACH ROW
    BEGIN
		UPDATE species SET current_name = "Dogo" WHERE ID = 1;
	END |
    
    UPDATE animals SET name = "Snorry" WHERE id = 3 |
    
    SHOW TRIGGERS;
    
    -- this trigger ensures that any update operaton on the 'animals' table will not set the 'sex' column to a value other than 'M' or 'F'
    -- if an invalid value is detected, it sets the 'sex' column to NULL
    DROP TRIGGER IF EXISTS verify_sex BEFORE UPDATE ON animals FOR EACH ROW
    BEGIN
		IF NEW.sex IS NOT NULL AND NEW.sex != 'M' AND NEW.sex != 'F' THEN
			SET NEW.sex = NULL;
		END IF;
	END |
    
    UPDATE animals SET sex = 'M' WHERE id = 1 |
    
    -- to remove a TRIGGER
    DROP TRIGGER test |
    UPDATE species SET current_name = 'dog' WHERE id = 1;
    