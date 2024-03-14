-- 1. 1.	Build a query and save it as a view that displays all rentals, 
-- with the surname of the customer and of the employee who gave the film and the store to which the employee belongs, assigning- to each field a nickname.
CREATE OR REPLACE VIEW view_display_rentals AS
SELECT 
    rental.rental_id,
    customer.last_name AS customer_last_name,
    staff.last_name AS staff_last_name,
    staff.store_id AS staff_store_id
FROM rental
JOIN customer ON rental.customer_id = customer.customer_id
LEFT JOIN staff ON rental.staff_id = staff.staff_id;



SELECT 
    view_display_rentals.rental_id,
    view_display_rentals.customer_last_name,
    view_display_rentals.staff_last_name,
    view_display_rentals.staff_store_id,
    manager.last_name AS store_manager_last_name
FROM 
    view_display_rentals
LEFT JOIN staff AS manager ON view_display_rentals.staff_store_id = manager.store_id
ORDER BY 
    view_display_rentals.staff_last_name;








