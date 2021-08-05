Use SimplyStorage;
GO

INSERT INTO Usuario (Nome, Email, Senha)
VALUES ('Camila', 'camila@email.com','ca123'),
       ('Ian', 'ian@email.com', 'ian132'),
	   ('Gustavo','gustavo@email.com', 'gus123'),
	   ('Danilo', 'danilo@email.com', 'dan123')
	   GO



INSERT INTO Sala (Nome, Andar, Metragem)
VALUES ('SimplyStorage', '1', '60.5 x 80')
	   GO



INSERT INTO TipoEquipamento (Nome)
VALUES ('mobiliário'),
       ('informática'),
	   ('papelaria')
	   GO


	
INSERT INTO Equipamento (CodSala, TipoEquipamento, Marca, NumeroPatrimonio, Descricao, BitAtivo)
VALUES (1,2,'Dell',1.1,'PC',1),
       (1,2,'Apple',1.2,'Notebook',0),
	   (1,2,'Samsung',1.3,'Celular',1),
	   (1,3,'Hitachi',1.4,'Lousa Interativa',1)
GO