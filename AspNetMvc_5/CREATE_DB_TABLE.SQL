﻿USE ANDREW2

CREATE TABLE BILLS (
	NUMERO INT NOT NULL IDENTITY(1000,1) PRIMARY KEY,
	FILENAME NVARCHAR(50) NOT NULL,	
	DESCRIPTION NVARCHAR(50) NOT NULL,
	DATE_DOC DATETIME NOT NULL,
	DATE_PAY DATETIME NOT NULL,
	DATE_ADD DATETIME NOT NULL,
	AMOUNT SMALLMONEY NOT NULL,
	CONTRAGENT_ID INT NOT NULL,
	PERIOD_ID INT NOT NULL,
	TYPES_ID INT NOT NULL
)

CREATE TABLE CONTRAGENTS (
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	NAME NVARCHAR(20) NOT NULL
)

CREATE TABLE TYPESOFDOC (
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	TYPEOFDOC NVARCHAR(20) NOT NULL
)

CREATE TABLE PERIODS (
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	SETTLEMENTPERIOD NVARCHAR(20) NOT NULL
)

ALTER TABLE BILLS ADD CONSTRAINT FK_BILLS_CONTRAGENTS FOREIGN KEY (CONTRAGENT_ID) REFERENCES CONTRAGENTS (ID);
ALTER TABLE BILLS ADD CONSTRAINT FK_BILLS_TYPES FOREIGN KEY (TYPES_ID) REFERENCES TYPESOFDOC (ID);
ALTER TABLE BILLS ADD CONSTRAINT FK_BILLS_PERIODS FOREIGN KEY (PERIOD_ID) REFERENCES PERIODS (ID);

INSERT INTO CONTRAGENTS VALUES ('Компанія А')
INSERT INTO CONTRAGENTS VALUES ('Компанія Б')
INSERT INTO CONTRAGENTS VALUES ('Компанія В')

INSERT INTO TYPESOFDOC VALUES ('Акт')
INSERT INTO TYPESOFDOC VALUES ('Рахунок')	
INSERT INTO TYPESOFDOC VALUES ('Накладна')
INSERT INTO TYPESOFDOC VALUES ('Інформація')

INSERT INTO PERIODS VALUES ('2014')
INSERT INTO PERIODS VALUES ('2015')
INSERT INTO PERIODS VALUES ('2015-01')
INSERT INTO PERIODS VALUES ('2015-02')
INSERT INTO PERIODS VALUES ('2015-03')
INSERT INTO PERIODS VALUES ('2015-04')
INSERT INTO PERIODS VALUES ('2015-05')
INSERT INTO PERIODS VALUES ('2015-06')
INSERT INTO PERIODS VALUES ('2015-07')
INSERT INTO PERIODS VALUES ('2015-08')
INSERT INTO PERIODS VALUES ('2015-09')
INSERT INTO PERIODS VALUES ('2015-10')
INSERT INTO PERIODS VALUES ('2015-11')
INSERT INTO PERIODS VALUES ('2015-12')

SELECT * FROM PERIODS