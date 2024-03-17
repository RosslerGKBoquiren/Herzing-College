-- 1. STORED FUNCTION: count_backwards
DROP FUNCTION IF EXISTS count_backwards;
DELIMITER | 
CREATE FUNCTION count_backwards(x INT, y INT) RETURNS VARCHAR(255)
BEGIN
    DECLARE result VARCHAR(255) DEFAULT ''; -- variable to store result
    DECLARE i INT DEFAULT x; -- start counting backwards from x
    WHILE i >= y DO -- loop to count backwards from x to y
        SET result = CONCAT(result, i, ','); -- concatenate current number with result
        SET i = i - 1; -- decrement counter
    END WHILE;
    
    SET result = TRIM(TRAILING ',' FROM result);
    RETURN result;
END |


select zoo_2.count_backwards(10, 5);


-- 2. STORED FUNCTION: count_funny
DROP FUNCTION IF EXISTS count_funny;
DELIMITER | 
CREATE FUNCTION count_funny(x INT, y INT) RETURNS TEXT
BEGIN
    DECLARE result TEXT DEFAULT ''; -- variable to store result
    DECLARE i INT DEFAULT x; -- start counting backwards from x
    WHILE i >= y DO -- loop to count backwards from x to y
        IF i % 5 = 0 THEN -- verify if current number is divisible by 5
            SET result = CONCAT(result, i, ' <- funny\n'); -- concatenate current number with funny 
        ELSE
            SET result = CONCAT(result, i, '\n');
        END IF;
        SET i = i - 1; -- decrement counter
    END WHILE;
    RETURN result;
END |

select zoo_2.count_funny(10, 0);


-- 3. STORED FUNCTION: my_birthday
DROP FUNCTION IF EXISTS my_birthday;
DELIMITER |
CREATE FUNCTION my_birthday(birthday DATE) RETURNS TEXT
BEGIN
    DECLARE result TEXT DEFAULT ''; 
    DECLARE curr_date DATE;
    SET curr_date = '2024-01-01'; -- Start from January 1st of the year

    my_loop: WHILE curr_date <= '2024-12-31' DO
        SET result = CONCAT(result, '\n', curr_date); -- add the current date to the result
        IF curr_date = birthday THEN
            SET result = CONCAT(result, '\n', curr_date, ' <- My Birthday :D'); -- Add annotation on birthday
            LEAVE my_loop; -- Exit the loop when the current date matches the birthday
        END IF;
        SET curr_date = curr_date + 1; -- Move to the next day
    END WHILE;
    RETURN result;
END |

select zoo_2.my_birthday('2024-01-05');


-- 4. Create a function that retrieves the animal’s id and returns its price.
DROP FUNCTION IF EXISTS animal_price;
DELIMITER |
CREATE FUNCTION animal_price(animal_id INT) RETURNS DECIMAL(10, 2)
BEGIN
    DECLARE price DECIMAL(10, 2);
    
    SELECT COALESCE(races.price, species.price) INTO price
    FROM animals
    LEFT JOIN races ON races.id = animals.race_id
    LEFT JOIN species ON species.id = animals.species_id
    WHERE animals.id = animal_id;
    
    RETURN price;
END |

SELECT 
    name, 
    dob, 
    sex, 
    species_id, 
    mother_id,
    animal_price(id) AS price 
FROM 
    animals;


-- 5.	Add a new column to the "species" table to show the count of each species number found in the "animal" 
-- table by utilizing the "count_species" function and inserting the appropriate values

-- adding count_species function
DROP FUNCTION IF EXISTS count_species;
DELIMITER |
CREATE FUNCTION count_species(s_id INT) RETURNS INT
BEGIN
	DECLARE num INT;
    SELECT COUNT(*) INTO num
    FROM animals
    WHERE species_id = s_id;
    RETURN num;
END|
-- add new column species_number to species table
ALTER TABLE species ADD COLUMN species_number INT;
-- populate species_number using function count_species
UPDATE species SET species_number = count_species(id);

-- create trigger that updates column species_number each time a record is inserted into 'animals' table
DROP TRIGGER IF EXISTS column_update;
DELIMITER |
CREATE TRIGGER column_update AFTER INSERT ON animals
FOR EACH ROW
BEGIN
    DECLARE species_count INT; -- variable to store count
    -- count number newly inserted row in animals table
    SELECT COUNT(*) INTO species_count
    FROM animals
    WHERE species_id = NEW.species_id;
    -- update column with count
    UPDATE species
    SET species_number = species_count
    WHERE id = NEW.species_id;
END |

-- to test insert a new record in animal table
INSERT INTO animals(species_id, sex, dob, name)
VALUES (5, 'M', '2024-01-01 15:42:00', 'Nissin');

SELECT * FROM zoo_2.animals;
