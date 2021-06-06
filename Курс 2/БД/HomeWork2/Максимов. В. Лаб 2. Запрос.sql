
  --Задание 1

CREATE OR ALTER FUNCTION sum_number(@number1 INT, @number2 INT)
  RETURNS INT
  AS
  BEGIN
  	RETURN(@number1+@number2)
  END;

SELECT dbo.sum_number(2,1)

  --Задание 2

CREATE TYPE arr_type AS TABLE
  (value INT)

CREATE OR ALTER FUNCTION dbo.array_sum(@arr arr_type READONLY)
  RETURNS INT
  AS
  BEGIN
    DECLARE @res INT = (SELECT SUM(value) FROM @arr)
    RETURN @res
  END

DECLARE @arr arr_type
INSERT INTO @arr (value)
  VALUES (1),(2),(3), (4), (5);

SELECT dbo.array_sum(@arr)

  --задание 3

CREATE OR ALTER FUNCTION get_current_date_time()
RETURNS NVARCHAR(100)
AS
BEGIN
  DECLARE @date DATETIME=GETDATE();
  RETURN CONCAT(CONVERT(NVARCHAR, @date, 104) ,' ', SUBSTRING(CONVERT(NVARCHAR, @date, 8), 1, 5));
END

SELECT dbo.get_current_date_time()

  --Задание 4

CREATE OR ALTER FUNCTION remove_numbers_connect(@text1 NVARCHAR(200), @text2 NVARCHAR(200))
  RETURNS NVARCHAR(400)
  AS
  BEGIN
    DECLARE @res NVARCHAR(400)=CONCAT(@text1, @text2)
      ,@i INT =0
    while @i <10 
      select @res = replace(@res , @i , ''), @i = @i + 1
   RETURN @res
  END;

SELECT dbo.remove_numbers_connect('asa12ghvhg43232gg3j', 'jh2jhv3324vvghv2323vgh23')


  --Задание 5

CREATE OR ALTER FUNCTION get_birth_most_young_chef()
  RETURNS DATETIME
  AS
  BEGIN
    RETURN (SELECT MAX(chef_birth) FROM chefs)
  END

SELECT dbo.get_birth_most_young_chef()

--Задание 6

CREATE OR ALTER FUNCTION get_chef_by_id(@id INT)
  RETURNS NVARCHAR(100)
  AS
  BEGIN
    RETURN (SELECT CONCAT(c.chef_first_name, ' ', c.chef_second_name) FROM chefs c
            WHERE c.chef_id=@id)
  END

SELECT dbo.get_chef_by_id(1)

  --Задание 7

CREATE OR ALTER FUNCTION fib(@n INT)
  RETURNS INT
  AS 
  BEGIN
    DECLARE @prev INT=0
            ,@dop INT
            ,@res INT=1
    WHILE @n>1
       SELECT @dop=@res, @res=@res+@prev, @prev=@dop,  @n=@n-1
      RETURN @res
  END

SELECT dbo.fib(46)

  --Задание 8

CREATE OR ALTER PROCEDURE split_by_pipeline(@string NVARCHAR(100), @left NVARCHAR(100)=NULL OUT, @right NVARCHAR(100)=NULL OUT)
  AS 
  BEGIN
    DECLARE @index INT = CHARINDEX('|', @string);
    IF(@index=0)
      BEGIN
        SET @left=NULL;
        SET @right=NULL;
        RETURN
      END
    SET @left = SUBSTRING(@string, 1, @index-1);
    SET @right =SUBSTRING(@string, @index+1, LEN(@string) -@index )
  END

DECLARE @left NVARCHAR(100)
          ,@right NVARCHAR(100)
EXEC split_by_pipeline 'hello|world', @left OUT, @right OUT

SELECT @left, @right

  --Задание 9

CREATE OR ALTER FUNCTION IsPalindrome(@string NVARCHAR(100))
  RETURNS BIT
  AS
  BEGIN
    SET @string= LOWER(REPLACE(@string, ' ', ''));
    IF(@string=REVERSE(@string))
      RETURN 1;
    RETURN 0;
  END

SELECT dbo.IsPalindrome('А роза упала на лапу Азора')

--Задание 10

CREATE OR ALTER TRIGGER chef_skill_links_task1
  ON chef_skill_links 
  AFTER UPDATE
  AS 
  BEGIN
    IF EXISTS(SELECT d.chef_id FROM DELETED d
              WHERE DATEADD(YEAR, 5, (SELECT MIN(csl.date_from) 
                                      FROM chef_skill_links csl
                                      WHERE csl.chef_id=d.chef_id))<=GETDATE())
    THROW 55000, 'Нельзя изменять умения поворов с опытом больше 5 лет', 1;
  END
   
 UPDATE chef_skill_links 
SET skill_id = 3
WHERE chef_id = 10
AND skill_id = 8;

  --task 11
CREATE TABLE event_types
  (event_type_id INT PRIMARY KEY IDENTITY
  ,event_type NVARCHAR(20))

INSERT INTO event_types VALUES ('Добавление'), ('Изменение'), ('Удаление')

CREATE TABLE audit_chefs
  (id INT PRIMARY KEY IDENTITY
  ,event_type_id INT REFERENCES event_types(event_type_id) NOT NULL
  ,date DATETIME NOT NULL
  ,chef_id INT NOT NULL
  ,chef_first_name NVARCHAR(100)
 ,chef_second_name NVARCHAR(100)
 ,chef_birth DATE)

CREATE OR ALTER TRIGGER chefs_after_insert_delete
  ON chefs AFTER DELETE, INSERT
  AS
  BEGIN
    INSERT INTO audit_chefs (event_type_id, date, chef_id, chef_first_name, chef_second_name, chef_birth)
        SELECT 1, GETDATE(), chef_id, chef_first_name, chef_second_name, chef_birth
        FROM INSERTED

      INSERT INTO audit_chefs (event_type_id, date, chef_id, chef_first_name, chef_second_name, chef_birth)
        SELECT 3, GETDATE(), chef_id, chef_first_name, chef_second_name, chef_birth
        FROM DELETED
  END

CREATE OR ALTER TRIGGER chefs_after_update
  ON chefs AFTER UPDATE
  AS
  BEGIN
    INSERT INTO audit_chefs (event_type_id, date, chef_id, chef_first_name, chef_second_name, chef_birth)
        SELECT 2, GETDATE(), chef_id, chef_first_name, chef_second_name, chef_birth
        FROM INSERTED
  END


INSERT INTO chefs (chef_first_name, chef_second_name, chef_birth) VALUES 
  ('Test', 'test', DATEFROMPARTS(1999, 12,1))

UPDATE chefs 
SET chef_first_name = N'tt'
   ,chef_second_name = N'tt'
WHERE chef_id = 17;

DELETE chefs
  WHERE chef_id=17;


SELECT id
      ,event_type
      ,date
      ,chef_id
      ,chef_first_name
      ,chef_second_name
      ,chef_birth 
  FROM audit_chefs
  JOIN event_types et ON audit_chefs.event_type_id = et.event_type_id 

--Задание 12

CREATE TRIGGER audit_chefs_after_delete_update
  ON audit_chefs
  AFTER DELETE, UPDATE
  AS
  THROW 55001, 'В данной табличке запрещено изменять/удалять даанные.', 1;

CREATE TRIGGER sss
  ON DATABASE
  FOR 

DELETE audit_chefs
  WHERE id=1;