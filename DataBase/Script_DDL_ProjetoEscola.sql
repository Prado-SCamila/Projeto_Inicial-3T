CREATE DATABASE SimplyStorage;
GO

USE SimplyStorage;
GO


CREATE TABLE Usuario
(
 CodUsuario INT PRIMARY KEY IDENTITY,
 Nome VARCHAR (250) NOT NULL,
 Email VARCHAR (250) NOT NULL,
 Senha VARCHAR(250) NOT NULL
);
GO


CREATE TABLE Sala
(
CodSala INT PRIMARY KEY IDENTITY,
Nome VARCHAR(250) NOT NULL,
Andar INT NOT NULL,
Metragem VARCHAR(300) NOT NULL,
);
GO

CREATE TABLE TipoEquipamento
(
CodTipo INT PRIMARY KEY IDENTITY,
Nome VARCHAR(250) NOT NULL
);
GO

CREATE TABLE Equipamento
(
CodEquipamento INT PRIMARY KEY IDENTITY,
CodSala INT FOREIGN KEY REFERENCES Sala (CodSala),
TipoEquipamento INT FOREIGN KEY REFERENCES TipoEquipamento(CodTipo),
Marca VARCHAR(250) NOT NULL,
NumeroSerie UNIQUEIDENTIFIER NOT NULL DEFAULT Newid(),
NumeroPatrimonio DECIMAL(18,3) NOT NULL,
Descricao VARCHAR(250) NOT NULL,
BitAtivo BIT NOT NULL
);
GO

select * from Usuario
select * from Sala
select * from TipoEquipamento
select * from Equipamento

