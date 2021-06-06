CREATE TABLE passwords
  (password_id INT PRIMARY KEY IDENTITY
  ,account_id INT REFERENCES accounts(account_id)
  ,password nvarchar(50)
  ,date_from DATETIME
  ,date_to DATETIME NULL)