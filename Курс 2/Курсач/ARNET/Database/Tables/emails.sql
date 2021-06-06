CREATE TABLE emails(
  email_id INT PRIMARY KEY IDENTITY
  ,account_id INT REFERENCES accounts(account_id) NOT NULL
  ,email nvarchar(30) NOT NULL
  ,date_from DATETIME NOT NULL
  ,date_to DATETIME NULL)