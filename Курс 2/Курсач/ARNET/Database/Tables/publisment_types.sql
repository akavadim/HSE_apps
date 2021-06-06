CREATE TABLE publishment_types
  (publishment_type_id INT PRIMARY KEY IDENTITY
  ,type NVARCHAR(20))

INSERT INTO publishment_types (name) VALUES 
  ('Rent dayly')
  ,('Rent long')
  ,('Sale')