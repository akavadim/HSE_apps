CREATE TABLE publishments
  (publishment_id INT PRIMARY KEY IDENTITY
  ,account_id INT REFERENCES accounts(account_id)
  ,apartment_id INT REFERENCES apartments(apartment_id)
  ,publishmet_type_id INT REFERENCES publishment_types(publishment_type_id)
  ,date_from DATETIME
  ,date_to DATETIME NULL)