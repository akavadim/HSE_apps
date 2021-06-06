CREATE TABLE publishment_specification_links
  (publishment_specification_id INT PRIMARY KEY IDENTITY
  ,publishment_id INT REFERENCES publishments(publishment_id)
  ,specification_id INT REFERENCES specifications(specification_id) 
  ,value NVARCHAR(30)
  ,date_from DATETIME
  ,date_to DATETIME NULL)