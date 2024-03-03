-- Part I - Add fields: mother_id and father_id
-- to match data_type of ID for part II change INT to SMALLINT
ALTER TABLE animals
ADD COLUMN mother_id SMALLINT,
ADD COLUMN father_id SMALLINT;