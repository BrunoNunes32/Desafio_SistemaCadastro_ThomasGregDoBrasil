CREATE DATABASE Desafio_SistemaCadastro_ThomasGregDoBrasil;

USE Desafio_SistemaCadastro_ThomasGregDoBrasil
GO;

CREATE TABLE Clientes(
	 ClienteId INT IDENTITY(1,1)
	,Nome		VARCHAR(255) NOT NULL
	,Email		VARCHAR(255) UNIQUE
	,Logotipo	VARBINARY(MAX)
);
ALTER TABLE Clientes ADD CONSTRAINT PK_Clientes_ClienteId PRIMARY KEY (ClienteId);

CREATE TABLE Logradouros(
	 LogradouroId INT IDENTITY(1,1)
	,ClienteId INT NOT NULL 
	,Endereco VARCHAR(255) NOT NULL
);
ALTER TABLE Logradouros ADD CONSTRAINT PK_Logradouros_LogradouroId PRIMARY KEY (LogradouroId);
ALTER TABLE Logradouros ADD CONSTRAINT FK_Logradouros_ClienteId FOREIGN KEY (ClienteId) REFERENCES Clientes(ClienteId);

CREATE INDEX IX_Clientes_Email ON Clientes (Email);
CREATE INDEX IX_Logradouros_ClienteID ON Logradouros (ClienteID);
