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