-- CREATE new table 'races'
CREATE TABLE races (id INT AUTO_INCREMENT PRIMARY KEY, name VARCHAR(255), species_id INT, description TEXT, FOREIGN KEY (species_id) REFERENCES species(id)) 
ENGINE=InnoDB;