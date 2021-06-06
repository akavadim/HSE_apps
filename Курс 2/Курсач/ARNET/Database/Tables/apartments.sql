CREATE TABLE apartments
  (apartment_id INT PRIMARY KEY IDENTITY
  ,accomodation_id INT REFERENCES accommodations(accommodation_id)
  ,description NVARCHAR
  ,date_from DATETIME
  ,date_to DATETIME NULL)