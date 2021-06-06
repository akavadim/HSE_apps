CREATE TABLE accommodation_specification_links
  (accomodation_specification_id INT PRIMARY KEY IDENTITY
  ,accomodation_id INT REFERENCES accommodations(accommodation_id)
  ,specification_id INT REFERENCES specifications(specification_id)
  ,value NVARCHAR(30)
  ,date_from DATETIME 
  ,date_to DATETIME NULL)