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