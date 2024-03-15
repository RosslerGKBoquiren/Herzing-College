#######  TIGGERS #####

CREATE TRIGGER test BEFORE UPDATE ON animal FOR EACH ROW
BEGIN
	UPDATE species SET current_name = "Dogo" WHERE id = 1;
END|

UPDATE animal SET name = 'Roxy' WHERE id = 1 |

SHOW TRIGGERS;

CREATE TRIGGER verify_sex BEFORE UPDATE ON animal FOR EACH ROW
BEGIN
	IF NEW.sex IS NOT NULL AND NEW.sex != 'M' AND NEW.sex != 'F' THEN
		SET NEW.sex = NULL;
	END IF;
END|

UPDATE animal SET sex = 'X' WHERE id = 1 |



-- to remove a TRIGGER
DROP TRIGGER test|








