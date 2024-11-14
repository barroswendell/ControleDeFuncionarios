﻿CREATE TABLE FUNCIONARIO(
ID	          UNIQUEIDENTIFIER         PRIMARY KEY,
NOME          VARCHAR(150)             NOT NULL,
CPF           VARCHAR(11)              NOT NULL,
SALARIO       DECIMAL(10,2)            NOT NULL,
TIPO          INT                      NOT NULL,
CHECK(TIPO IN(1,2,3)));
GO