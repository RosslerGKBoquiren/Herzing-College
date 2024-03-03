-- Part II Add Foreign Key to both (reference table is the same table)
-- Add Foreign Key to mother_id
ALTER TABLE animals
ADD CONSTRAINT mother_id_foreign
FOREIGN KEY (mother_id) REFERENCES animals(id);

-- Add Foreign Key to father_id
ALTER TABLE animals
ADD CONSTRAINT father_id_foreign
FOREIGN KEY (father_id) REFERENCES animals(id);



