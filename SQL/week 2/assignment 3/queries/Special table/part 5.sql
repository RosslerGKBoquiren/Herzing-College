-- Make column 'species_id' not null
ALTER TABLE animals
MODIFY COLUMN species_id INT NOT NULL;

-- Add unique index on columns 'name' and 'species_id'
ALTER TABLE animals
ADD UNIQUE INDEX unique_name_id (name, species_id);