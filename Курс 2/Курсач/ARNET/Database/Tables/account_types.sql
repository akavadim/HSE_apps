CREATE TABLE account_types
(account_type_id INT PRIMARY KEY IDENTITY
,name NVARCHAR(25) NOT NULL UNIQUE)

INSERT INTO account_types (name) VALUES
('Administrator')
,('Moderator')
,('Agency')
,('Agent')
,('User')