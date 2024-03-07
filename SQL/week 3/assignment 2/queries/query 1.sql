-- Update all the dog's nulled comments to "woff, woff, woff"
UPDATE animals
SET comments = 'woff, woff, woff'
WHERE species_id = 1 AND comments IS NULL;

