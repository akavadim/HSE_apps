CREATE TABLE countries(
country_id INT PRIMARY KEY IDENTITY
,name NVARCHAR(50))

CREATE TABLE cities(
city_id INT PRIMARY KEY IDENTITY
,country_id INT REFERENCES countries(country_id)
,name NVARCHAR(100))

CREATE TABLE streets(
street_id INT PRIMARY KEY IDENTITY
,city_id INT REFERENCES cities(city_id)
,name NVARCHAR(100))

CREATE TABLE houses(
  house_id INT PRIMARY KEY IDENTITY
  ,street_id INT REFERENCES streets(street_id)
  ,number INT
  ,litera NVARCHAR(3) NULL)