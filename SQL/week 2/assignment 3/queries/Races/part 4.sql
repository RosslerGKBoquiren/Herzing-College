-- Part IV - Add Foreign Key to race_id
ALTER TABLE animals
ADD CONSTRAINT race_id_foreign
FOREIGN KEY (race_id) REFERENCES races(id);

