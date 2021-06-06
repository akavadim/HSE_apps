CREATE TABLE regions(
  region_id INT PRIMARY KEY IDENTITY
  ,country_id INT REFERENCES countries(country_id)
  ,region NVARCHAR(30))