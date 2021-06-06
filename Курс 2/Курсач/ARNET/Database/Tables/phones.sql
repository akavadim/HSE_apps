CREATE TABLE phones(
  phone_id INT PRIMARY KEY
  ,account_id INT REFERENCES accounts(account_id)
  ,phone NVARCHAR(20)
  ,date_from DATETIME
  ,date_to DATETIME NULL)