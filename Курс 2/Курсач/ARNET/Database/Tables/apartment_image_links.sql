CREATE TABLE apartment_image_links
  (apartment_image_id INT PRIMARY KEY IDENTITY
  ,apartment_id INT REFERENCES apartments(apartment_id)
  ,image_id INT REFERENCES images(image_id))