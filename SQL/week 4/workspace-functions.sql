USE zoo;

DELiMITER |
######  FUNCTIONS ######
CREATE FUNCTION test_function() RETURNS VARCHAR(50)
BEGIN
	RETURN 'Herzing College Montreal';
END|




CREATE FUNCTION count_species(s_id INT) RETURNS INT(7)
BEGIN
	DECLARE num INT(7);
    SELECT COUNT(*) INTO num
    FROM animal
    WHERE species_id = s_id;
	
    RETURN num;
END|





SELECT count_species(1) number_of_dog |
SELECT test_function() School |
SELECT species_id, GROUP_CONCAT(id), group_concat(name), count_species(species_id) FROM animal group by species_id;



CREATE FUNCTION get_species_name(s_id INT) RETURNS VARCHAR(50)
BEGIN
	DECLARE s_name VARCHAR(50);
    
    SELECT current_name INTO s_name 
    FROM species 
    WHERE id = s_id;
    
    RETURN s_name;
END |





SELECT name, dob, sex, get_species_name(species_id) Specie
FROM animal
WHERE id = 1 |

-- to remove a Function:
# DROP FUNCTION get_species_name |





CREATE FUNCTION get_mother_name(a_id INT) RETURNS VARCHAR(50)
BEGIN
	DECLARE m_name VARCHAR(50);
    
    SELECT COALESCE(m.name, 'No Mommy') INTO m_name
    FROM animal c
    LEFT JOIN animal m
    ON c.mother_id = m.id
    WHERE c.id = a_id;
    
    
    RETURN m_name;
END |

SELECT name, sex, dob, get_mother_name(id) Mom
FROM animal 
WHERE id = 25 |





