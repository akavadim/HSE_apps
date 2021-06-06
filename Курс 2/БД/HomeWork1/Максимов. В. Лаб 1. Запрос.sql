--Задание 1

CREATE TABLE chefs
  (chef_id int PRIMARY KEY IDENTITY
  ,chef_first_name nvarchar(100)
  ,chef_second_name nvarchar(100)
  ,chef_birth date)

CREATE NONCLUSTERED INDEX IX_second_name 
ON chefs(chef_second_name) 
INCLUDE (chef_first_name)

CREATE NONCLUSTERED INDEX IX_birth 
ON chefs(chef_birth)
     

  --Задание 10 --В задание 2 добавленые столбцы с ссылками на таблицы из задания 10

CREATE TABLE skill_groups(
  group_id INT PRIMARY KEY IDENTITY
  ,group_name NVARCHAR(50))

CREATE TABLE skill_categories(
  category_id INT PRIMARY KEY IDENTITY
  ,category_name varchar(50))

INSERT INTO skill_groups(group_name) VALUES
  ('Холодные закуски')
  ,('Гарниры')
  ,('Выпечка')
  ,('Десерты')
  ,('Напитки')

INSERT INTO skill_categories (category_name) VALUES 
  ('Сложные рецепты')
  ,('Легкие рецепты')
  ,('Рецепты требующие особых навыков')

--Задание 2

CREATE TABLE cooking_skills
  (skill_id int PRIMARY KEY IDENTITY
  ,skill_name nvarchar(50)
  ,group_id INT NULL REFERENCES skill_groups(group_id)
  ,category_id INT NULL REFERENCES skill_categories(category_id))

CREATE NONCLUSTERED INDEX IX_name
ON cooking_skills(skill_name)
INCLUDE (skill_id)
  
--Задание 3

CREATE TABLE chef_skill_links
  (chef_id int REFERENCES chefs(chef_id)
  ,skill_id int REFERENCES cooking_skills(skill_id)
  ,date_from date
  ,PRIMARY KEY(chef_id, skill_id))

CREATE NONCLUSTERED INDEX IX_date_from 
ON chef_skill_links (date_from)  


INSERT INTO chefs (chef_first_name, chef_second_name, chef_birth) VALUES 
  ('Иван', 'Иванов', DATEFROMPARTS(1980, 02, 01))
  ,('Неиван', 'Неиванов', DATEFROMPARTS(1999, 03, 02)) 
  ,('Александ', 'Городецкий', DATEFROMPARTS(2000, 04, 03)) 
  ,('Кирилл', 'Меркурьев', DATEFROMPARTS(1971, 05, 05)) 
  ,('Валерий', 'Фрилансер', DATEFROMPARTS(1982, 06, 08)) 
  ,('Петро', 'Порошенко', DATEFROMPARTS(1995, 07, 10)) 
  ,('Владимир', 'Путин', DATEFROMPARTS(1988, 07, 25)) 
  ,('Сергей', 'Собянин', DATEFROMPARTS(1964, 08, 20))
  ,('Веселый', 'Поваренок', DATEFROMPARTS(1996, 11, 01))
  ,('Соня', 'Мармеладова', DATEFROMPARTS(1943, 9, 4))
  ,('Ника', 'Милославская', DATEFROMPARTS(1954, 6, 12))
  ,('Кристина', 'Борисовна', DATEFROMPARTS(1966, 3, 21))
  ,('Аня', 'Брежнева', DATEFROMPARTS(2000, 2, 01))
  ,('Карина', 'Каспийская', DATEFROMPARTS(1930, 10, 27))
  ,('Анфиса', 'Томбовская', DATEFROMPARTS(1970, 12, 19))
  ,('Ева', 'Немцова', DATEFROMPARTS(1986, 7, 11))
      
INSERT INTO cooking_skills(skill_name, group_id, category_id) VALUES
  ('Выпекание тортов', 3, 2)
  ,('Выпекание пирожных', 4, 2)
  ,('Утка по-пекински', 2, 3)
  ,('Приготовление морепродуктов', null, 1)
  ,('Приготовление супов', null, 1)
  ,('Приготовление салатов', 1, 1)
  ,('Горящие напитки', 5, 3)
  ,('Коктейли', 5, 1)
 
INSERT INTO chef_skill_links(chef_id, skill_id, date_from) VALUES
   (1,1, DATEFROMPARTS(1990,2,3)),(1,2,DATEFROMPARTS(1990,3,5))
  ,(2,3, DATEFROMPARTS(2015,4,10)),(2,4,DATEFROMPARTS(2010,4,20)),(2,5,DATEFROMPARTS(2015,7,8)),(2,6,DATEFROMPARTS(2019,10,1))
  ,(3,7,DATEFROMPARTS(2018,12,21)),(3,8,DATEFROMPARTS(2019,9,7))
  ,(4,2,DATEFROMPARTS(2017,5,30)),(4,4,DATEFROMPARTS(2000,4,7))
  ,(5,1,DATEFROMPARTS(2000,2,3)),(5,3,DATEFROMPARTS(2001,2,5)),(5,7,DATEFROMPARTS(2002,3,7))
  ,(6,3,DATEFROMPARTS(2015,6,7)),(6,4,DATEFROMPARTS(2019,7,15))
  ,(7,7,DATEFROMPARTS(1999,1,1))
  ,(8,1,DATEFROMPARTS(2010,3,2)),(8,3,DATEFROMPARTS(1989,8,13)),(8,4,DATEFROMPARTS(2013,6,23))
  ,(9,2,DATEFROMPARTS(2014,12,23)),(9,5,DATEFROMPARTS(2016,11,27))
  ,(10,1,DATEFROMPARTS(1971,9,15)),(10,8,DATEFROMPARTS(1945,5,8))
  ,(11,3,DATEFROMPARTS(2001,9,11))
  ,(12,1,DATEFROMPARTS(2000,5,7)),(12,2,DATEFROMPARTS(1990,2,3)),(12,3,DATEFROMPARTS(1990,7,15)),(12,4,DATEFROMPARTS(1995,6,26)),(12,5,DATEFROMPARTS(2011,4,13)),(12,6,DATEFROMPARTS(2015,11,22)),(12,7,DATEFROMPARTS(2018,10,15)),(12,8,DATEFROMPARTS(1999,2,13))
  ,(13,3,DATEFROMPARTS(2013,6,19)),(13,5,DATEFROMPARTS(2020,1,13)),(13,8,DATEFROMPARTS(2010,6,1))
  ,(14,2,DATEFROMPARTS(1967,12,3)),(14,5,DATEFROMPARTS(2010,8,12))
  ,(15,4,DATEFROMPARTS(1997,3,2)),(15,5,DATEFROMPARTS(2008,4,21)),(15,7,DATEFROMPARTS(2007,6,20)),(15,8,DATEFROMPARTS(2019,6,13))
  ,(16,2,DATEFROMPARTS(2000,5,2)),(16,5,DATEFROMPARTS(2002,6,19))

--Смотрим, что получилось
SELECT chef_first_name, chef_second_name, chef_birth, skill_name, category_name, group_name FROM chefs
JOIN chef_skill_links ON chefs.chef_id = chef_skill_links.chef_id
LEFT JOIN cooking_skills ON chef_skill_links.skill_id = cooking_skills.skill_id
LEFT JOIN skill_categories ON cooking_skills.category_id = skill_categories.category_id
LEFT JOIN skill_groups ON cooking_skills.group_id = skill_groups.group_id

--Задание 4

SELECT chef_first_name, chef_second_name, chef_birth 
FROM chefs
WHERE chef_id IN (SELECT chef_id 
                  FROM chef_skill_links
                  WHERE skill_id=1)

--Задание 5

SELECT MAX(chef_birth)
FROM chefs

--Задание 6

SELECT chef_first_name, chef_second_name, skill_name
FROM chefs
JOIN chef_skill_links ON chef_skill_links.chef_id = chefs.chef_id
JOIN cooking_skills ON cooking_skills.skill_id = chef_skill_links.skill_id
WHERE (DATEADD(YEAR, 30, chef_birth)<GETDATE()) 

--Задание 7

SELECT chef_first_name, chef_second_name 
FROM chefs
JOIN chef_skill_links ON chefs.chef_id = chef_skill_links.chef_id
JOIN cooking_skills ON chef_skill_links.skill_id = cooking_skills.skill_id
WHERE chef_skill_links.skill_id=2 
  AND DATEADD(YEAR, 20, chef_birth)>date_from

--Задание 8

SELECT
  chef_second_name
FROM chefs
WHERE LEFT(chef_second_name,1) = 'П'

--Задание 9

SELECT z.ages, COUNT(z.ages) FROM
(SELECT
CASE 
WHEN DATEADD(YEAR, 10, chef_birth)<=GETDATE()
  AND GETDATE()<DATEADD(YEAR, 20, chef_birth) 
THEN '10-20'
WHEN DATEADD(YEAR, 20, chef_birth)<=GETDATE()
  AND GETDATE()<DATEADD(YEAR, 30, chef_birth) 
THEN '20-30'
WHEN DATEADD(YEAR, 30, chef_birth)<=GETDATE()
  AND GETDATE()<DATEADD(YEAR, 40, chef_birth) 
THEN '30-40'
WHEN DATEADD(YEAR, 40, chef_birth)<=GETDATE()
  AND GETDATE()<DATEADD(YEAR, 50, chef_birth) 
THEN '40-50'
WHEN DATEADD(YEAR, 50, chef_birth)<=GETDATE()
  AND GETDATE()<DATEADD(YEAR, 60, chef_birth) 
THEN '50-60'
WHEN DATEADD(YEAR, 60, chef_birth)<=GETDATE()
  AND GETDATE()<DATEADD(YEAR, 70, chef_birth) 
THEN '60-70'
WHEN DATEADD(YEAR, 70, chef_birth)<=GETDATE()
  AND GETDATE()<DATEADD(YEAR, 80, chef_birth) 
THEN '70-80'
WHEN DATEADD(YEAR, 80, chef_birth)<=GETDATE()
  AND GETDATE()<DATEADD(YEAR, 90, chef_birth) 
THEN '80-90'
WHEN DATEADD(YEAR, 90, chef_birth)<=GETDATE()
  AND GETDATE()<=DATEADD(YEAR, 100, chef_birth) 
THEN '90-100'
ELSE 'Other'
END ages
FROM chefs) z
GROUP BY z.ages
