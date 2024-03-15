-- 1. STORE PROCEDURE: list_animals
-- Display the list of all the animals with animal name and race name
DROP PROCEDURE IF EXISTS list_animals;

DELIMITER |
CREATE PROCEDURE list_animals()
BEGIN
	SELECT animals.name AS animal_name, races.name AS race_name
    FROM animals
    LEFT JOIN races ON animals.race_id = races.id;
END |

CALL list_animals();

-- 2. STORE PROCEDURE: fetch_animal_age
DROP PROCEDURE IF EXISTS fetch_animal_age;

DELIMITER |
CREATE PROCEDURE fetch_animal_age(IN animal_id INT, OUT animal_age INT)
BEGIN
    DECLARE birth_year INT;
    DECLARE current_year INT;
    DECLARE birth_month INT;
    DECLARE current_month INT;
    DECLARE birth_day INT;
    DECLARE current_day INT;
    
    -- Retrieve the birth date components of the animal
    SELECT YEAR(dob), MONTH(dob), DAY(dob)
    INTO birth_year, birth_month, birth_day
    FROM animals
    WHERE id = animal_id;
    
    -- Get the current date components
    SELECT YEAR(NOW()), MONTH(NOW()), DAY(NOW())
    INTO current_year, current_month, current_day;
    
    -- Calculate the age of the animal
    SET animal_age = current_year - birth_year;
    
    -- Adjust age if the birthday hasn't occurred yet this year
    IF current_month < birth_month OR (current_month = birth_month AND current_day < birth_day) THEN
        SET animal_age = animal_age - 1;
    END IF;
END |


CALL fetch_animal_age(10, @age);
SELECT @age;


-- 3. STORE PROCEDURE: price_of_pets
DROP PROCEDURE IF EXISTS price_of_pets;

DELIMITER |
CREATE PROCEDURE price_of_pets(
    IN animal_id1 INT,
    IN animal_id2 INT,
    IN animal_id3 INT,
    OUT price1 DECIMAL(7,2),
    OUT price2 DECIMAL(7,2),
    OUT price3 DECIMAL(7,2)
)
BEGIN
    DECLARE species_price1 DECIMAL(7,2);
    DECLARE species_price2 DECIMAL(7,2);
    DECLARE species_price3 DECIMAL(7,2);
    
    DECLARE race_price1 DECIMAL(7,2);
    DECLARE race_price2 DECIMAL(7,2);
    DECLARE race_price3 DECIMAL(7,2);
    
    -- Fetch prices for animal 1
    SELECT COALESCE(races.price + species.price, species.price) 
    INTO race_price1
    FROM animals
    LEFT JOIN races ON animals.race_id = races.id
    LEFT JOIN species ON animals.species_id = species.id
    WHERE animals.id = animal_id1;
    
    -- Fetch prices for animal 2
    SELECT COALESCE(races.price + species.price, species.price) 
    INTO race_price2
    FROM animals
    LEFT JOIN races ON animals.race_id = races.id
    LEFT JOIN species ON animals.species_id = species.id
    WHERE animals.id = animal_id2;
    
    -- Fetch prices for animal 3
    SELECT COALESCE(races.price + species.price, species.price) 
    INTO race_price3
    FROM animals
    LEFT JOIN races ON animals.race_id = races.id
    LEFT JOIN species ON animals.species_id = species.id
    WHERE animals.id = animal_id3;
    
    -- Set output prices
    SET price1 = race_price1;
    SET price2 = race_price2;
    SET price3 = race_price3;
    
END |

CALL price_of_pets(4, 20, 55, @price1, @price2, @price3);
SELECT @price1, @price2, @price3;

-- 4. STORE PROCEDURE: total_age_of_animal
DROP PROCEDURE IF EXISTS total_age_of_animal;

DELIMITER |
CREATE PROCEDURE total_age_of_animals(IN animal_id1 INT, IN animal_id2 INT, IN animal_id3 INT, IN animal_id4 INT, IN animal_id5 INT, OUT total_cumulative_age INT)
BEGIN
    DECLARE animal_age1 INT;
    DECLARE animal_age2 INT;
    DECLARE animal_age3 INT;
    DECLARE animal_age4 INT;
    DECLARE animal_age5 INT;

    -- Retrieve the age of the first animal
    SELECT YEAR(NOW()) - YEAR(dob) INTO animal_age1
    FROM animals
    WHERE id = animal_id1;

    -- Retrieve the age of the second animal
    SELECT YEAR(NOW()) - YEAR(dob) INTO animal_age2
    FROM animals
    WHERE id = animal_id2;

    -- Retrieve the age of the third animal
    SELECT YEAR(NOW()) - YEAR(dob) INTO animal_age3
    FROM animals
    WHERE id = animal_id3;

    -- Retrieve the age of the fourth animal
    SELECT YEAR(NOW()) - YEAR(dob) INTO animal_age4
    FROM animals
    WHERE id = animal_id4;

    -- Retrieve the age of the fifth animal
    SELECT YEAR(NOW()) - YEAR(dob) INTO animal_age5
    FROM animals
    WHERE id = animal_id5;

    -- Calculate the total cumulative age
    SET total_cumulative_age := animal_age1 + animal_age2 + animal_age3 + animal_age4 + animal_age5;
END |

set @total_cumulative_age = 0;
call zoo_2.total_age_of_animals(5, 10, 15, 20, 55, @total_cumulative_age);
select @total_cumulative_age;

-- 5. STORE PROCEDURE: fetch_animal_parents
DROP PROCEDURE IF EXISTS fetch_animal_parents;

DELIMITER |
CREATE PROCEDURE fetch_animal_parents(IN animal_id INT)
BEGIN
    DECLARE mother_name VARCHAR(255);
    DECLARE father_name VARCHAR(255);

    -- Retrieve the names of the mother and father if they exist
    SELECT 
		(SELECT name FROM animals WHERE id = (SELECT mother_id FROM animals WHERE id = animal_id)),
		(SELECT name FROM animals WHERE id = (SELECT father_id FROM animals WHERE id = animal_id))
	INTO mother_name, father_name
	FROM animals
	WHERE id = animal_id;

    -- Check if both parents exist
    IF mother_name IS NOT NULL AND father_name IS NOT NULL THEN
        -- Both parents exist
        SELECT mother_name, father_name;
    ELSEIF mother_name IS NOT NULL THEN
        -- Only mother exists
        SELECT mother_name;
    ELSEIF father_name IS NOT NULL THEN
        -- Only father exists
        SELECT father_name;
    ELSE
        -- No parents exist
        SELECT 'No parents';
    END IF;
END |

CALL zoo_2.fetch_animal_parents(3);

-- 6. STORE PROCEDURE: fetch_animal_info
DROP PROCEDURE IF EXISTS fetch_animal_info;

DELIMITER |
CREATE PROCEDURE fetch_animal_info(IN animal_id INT)
BEGIN
    SELECT 
        COALESCE(animals.name, 'No name') AS "Animal Name",
        COALESCE(animals.sex, 'To Be Decided') AS "Gender",
        COALESCE(animals.dob, 'Unknown') AS "Date of Birth",
        COALESCE(races.name, 'Unknown') AS "Race"
    FROM animals
    LEFT JOIN races ON animals.race_id = races.id
    WHERE animals.id = animal_id;
END |

call zoo_2.fetch_animal_info(4);

-- 7. STORE PROCEDURE: Say_ma_name
DROP PROCEDURE IF EXISTS Say_ma_name;

DELIMITER |
CREATE PROCEDURE Say_ma_name(IN animal_id INT)
BEGIN
    DECLARE animal_name VARCHAR(255);
    DECLARE animal_age INT;
    DECLARE output_string VARCHAR(255) DEFAULT '';
    DECLARE i INT DEFAULT 1;
    
    -- Retrieve the name and age of the animal
    SELECT name, YEAR(CURDATE()) - YEAR(dob) INTO animal_name, animal_age
    FROM animals
    WHERE id = animal_id;
    
    -- Construct the output string
    SET output_string = CONCAT("I'm ", animal_age, " -> ", REPEAT(CONCAT(animal_name, ", "), animal_age - 1), animal_name);
    
    -- Output the final string
    SELECT output_string AS "Output";
END |

CALL zoo_2.Say_ma_name(52);


