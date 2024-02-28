SELECT store.store_id, address.address, SUM(payment.amount) AS total_revenue FROM store
JOIN address ON store.address_id = address.address_id
LEFT JOIN customer ON store.store_id = customer.store_id
LEFT JOIN payment ON customer.customer_id = payment.customer_id
GROUP BY store.store_id, address.address
ORDER BY store.store_id;