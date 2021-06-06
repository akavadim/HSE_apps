CREATE TABLE accommodations
  (accommodation_id INT PRIMARY KEY IDENTITY
  ,accommodation_type INT REFERENCES accommodation_types(accommodation_type_id)
  ,house_id INT REFERENCES houses(house_id)
  ,date_from DATETIME
  ,date_to DATETIME NULL)