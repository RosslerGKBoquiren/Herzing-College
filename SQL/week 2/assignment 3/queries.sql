-- SPECIES
-- Part I
USE zoo;
-- CREATE new table 'species'
CREATE TABLE species (id INT PRIMARY KEY, current_name VARCHAR(255), latin_name VARCHAR(255), description TEXT) 
ENGINE=InnoDB;

-- Part II
-- INSERT into the 'species' table
INSERT INTO species (current_name, latin_name, description)
VALUES
('Dog', 'Canis familiaris', 'A domesticated carnivorous mammal that typically has a long snout, and an acute sense of smell.'),
('Cat', 'Felis catus', 'A small domesticated carnivorous mammal with soft fur, a short snout, and retractile claws.'),
('Turtle', 'Testudo hermanni', 'A slow-moving reptile, enclosed in a scaly or leathery domed shell into which it can retract its head and thick legs.'),
('Parrot', 'Alipiopstitta xanthops', 'A bird, often vividly colored, with a short down-curved hooked bill, grasping feet, and a raucous voice, found esp. in the tropics and feeding on fruits and seeds.');

-- Part III
-- Add a new column: species_id in animals
ALTER TABLE animals
ADD COLUMN species_id INT;

-- Replace the old species name with the new species id from the species table
UPDATE animals
JOIN species ON animals.species = species.current_name
SET animals.species_id = species.id
WHERE animals.species IS NOT NULL
	AND animals.species_id IS NULL;

-- Delete the old species column
ALTER TABLE animals
DROP COLUMN species;

-- Add Foreign Key
ALTER TABLE animals
ADD FOREIGN KEY (species_id) REFERENCES species(id);

-- Part IV
-- Test: statement should fail
INSERT INTO animals(name, species_id, dob)
VALUES ('George', 5, '2009-02-23 12:54:00');

-- Part V
-- Make column 'species_id' not null
ALTER TABLE animals
MODIFY COLUMN species_id INT NOT NULL;

-- Add unique index on columns 'name' and 'species_id'
ALTER TABLE animals
ADD UNIQUE INDEX unique_name_id (name, species_id);


-- RACES
-- Part I
-- CREATE new table 'races'
CREATE TABLE races (id INT AUTO_INCREMENT PRIMARY KEY, name VARCHAR(255), species_id INT, description TEXT, FOREIGN KEY (species_id) REFERENCES species(id)) 
ENGINE=InnoDB;

-- Part II
-- INSERT records into the table created
INSERT INTO races (name, species_id, description)
VALUES 
('Affenpinscher', 1, 'An Affenpinscher generally weighs 6.5 to 13.2 pounds (2.9 to 6.0 kg) and stands 9 to 12 inches (23 to 30 cm) tall at the withers.'),
('Boxer', 1, 'The breed standard dictates that it must be in perfect proportion to the body and above all it must never be too light.[3] The greatest value is to be placed on the muzzle being of correct form and in absolute proportion to the skull.'),
('American Bully', 1, 'According to the American Bully Kennel Club the American bully has a well-defined, powerful appearance with straight, muscular legs. The head is medium-length and broad with a well-defined stop and high-set ears, which may be natural or cropped.'),
('American Curl', 2, 'The American Curl is a breed of cat characterized by its unusual ears, which curl back from the face toward the center of the back of the skull.'),
('Abyssinian', 2, 'The Abyssinian has alert, relatively large pointed ears. The head is broad and moderately wedge-shaped. Its eyes are almond-shaped and colors include gold, green, hazel, or copper. The paws are small and oval. The legs are slender in proportion to the body, with a fine bone structure. The Abyssinian has a fairly long tail, broad at the base and tapering to a point.'),
('Bengal', 2, 'Bengal cats have "wild-looking" markings, such as large spots, rosettes, and a light/white belly, and a body structure reminiscent of the leopard cat. A Bengals rosette spots occur only on the back and sides, with stripes elsewhere. The breed typically also features "mascara" (horizontal striping alongside the eyes), and foreleg striping.'),
('Chausie', 2, 'Chausies are bred to be medium to large in size, as compared to traditional domestic breeds (Chausie breed standard). Most Chausies are a little smaller than a male Maine Coon, for example, but larger than a Siamese. Adult Chausie males typically weigh 9 to 15 pounds. Adult females are usually 7 to 10 pounds.');

-- Part III
-- Add a new column: race_id in animals
ALTER TABLE animals
ADD COLUMN race_id INT;

-- update the animals table with the race
-- Affenpinscher
UPDATE animals SET race_id = 1 WHERE id IN (1, 13, 20, 18, 22, 25, 26, 28);
-- Boxer
UPDATE animals SET race_id = 2 WHERE id IN (12, 14, 19, 7);
-- American Bully
UPDATE animals SET race_id = 3 WHERE id IN (23, 17, 21, 27);
-- American Curl
UPDATE animals SET race_id = 4 WHERE id IN (33, 35, 37, 41, 44, 31, 3);
-- Abyssinian
UPDATE animals SET race_id = 5 WHERE id IN (43, 40, 30, 32, 42, 34, 39, 8);
-- Bengal
UPDATE animals SET race_id = 6 WHERE id IN (29, 36, 38);

-- Part IV - Add Foreign Key to race_id
ALTER TABLE animals
ADD CONSTRAINT race_id_foreign
FOREIGN KEY (race_id) REFERENCES races(id);


-- PARENTS
-- Part I - Add fields: mother_id and father_id
-- to match data_type of ID for part II change INT to SMALLINT
ALTER TABLE animals
ADD COLUMN mother_id SMALLINT,
ADD COLUMN father_id SMALLINT;

-- Part II Add Foreign Key to both (reference table is the same table)
-- Add Foreign Key to mother_id
ALTER TABLE animals
ADD CONSTRAINT mother_id_foreign
FOREIGN KEY (mother_id) REFERENCES animals(id);

-- Add Foreign Key to father_id
ALTER TABLE animals
ADD CONSTRAINT father_id_foreign
FOREIGN KEY (father_id) REFERENCES animals(id);

-- Part III - Update animal table with mother and father id
UPDATE animals SET mother_id = 18, father_id = 22 WHERE id = 1;
UPDATE animals SET mother_id = 7, father_id = 21 WHERE id = 10;
UPDATE animals SET mother_id = 41, father_id = 31 WHERE id = 3;
UPDATE animals SET mother_id = 40, father_id = 30 WHERE id = 2;
