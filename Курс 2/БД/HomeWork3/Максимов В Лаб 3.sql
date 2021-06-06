CREATE TABLE agreement_payments(
  agreement_id INT PRIMARY KEY,
  agreement_number INT,
  pay_value INT,
  pay_date DATETIME)

CREATE INDEX IDX_agreement_payments ON agreement_payments(pay_date, pay_value);
GO;

CREATE SEQUENCE s_payments
  MINVALUE 1
  START WITH 1
  INCREMENT BY 1;

GO;

INSERT INTO agreement_payments (agreement_id, agreement_number, pay_value, pay_date)
  VALUES (NEXT VALUE FOR s_payments , 1, 110, GETDATE()),
(NEXT VALUE FOR s_payments , 1, 115, DATEFROMPARTS(1999, 12,1)),
  (NEXT VALUE FOR s_payments , 1, 11, DATEFROMPARTS(2000, 12,1)),
  (NEXT VALUE FOR s_payments , 6, 120, DATEFROMPARTS(2020, 1,1)),
  (NEXT VALUE FOR s_payments , 5, 10, DATEFROMPARTS(2020, 1,2)),
  (NEXT VALUE FOR s_payments , 5, 83, DATEFROMPARTS(2020, 1,3)),
  (NEXT VALUE FOR s_payments , 4, 45, DATEFROMPARTS(2020, 1,4)),
  (NEXT VALUE FOR s_payments , 3, 23, DATEFROMPARTS(2020, 1,5)),
  (NEXT VALUE FOR s_payments , 2, 13, DATEFROMPARTS(2020, 1,6)),
  (NEXT VALUE FOR s_payments , 2, 310, DATEFROMPARTS(2020, 1,6))

SELECT current_value FROM sys.sequences 
  WHERE name='s_payments'

CREATE SYNONYM syn FOR agreement_payments;

CREATE VIEW test_v 
AS
SELECT s.pay_date, SUM(s.pay_value) [sum], COUNT(1) [cnt]
FROM syn s
GROUP BY s.pay_date