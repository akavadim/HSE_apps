CREATE TABLE apartment_specification_links
  (apartment_specification_id INT PRIMARY KEY IDENTITY
  ,specification_id INT REFERENCES specifications(specification_id)
  ,apartment_id INT REFERENCES apartments(apartment_id)
  ,date_from DATETIME
  ,date_to DATETIME NULL)