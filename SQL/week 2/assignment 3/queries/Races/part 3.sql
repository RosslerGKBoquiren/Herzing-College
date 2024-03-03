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
