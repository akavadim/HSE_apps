CREATE TABLE accounts(
account_id INT PRIMARY KEY IDENTITY
,account_type_id INT REFERENCES account_types(account_type_id)
,image_id INT REFERENCES images(image_id) NULL
,inviter_id INT REFERENCES accounts(account_id) NULL 
,first_name NVARCHAR(25)
,second_name NVARCHAR(25)
,middle_name NVARCHAR(25) NULL
,date_from DATETIME
,date_to DATETIME NULL)