
Create table [Cidades]
(
	[Est_UF] Char(2) NOT NULL,
	[Cid_CodIBGE] Char(7) NOT NULL,
	[Cid_Nome] Varchar(100) NOT NULL,
Primary Key ([Est_UF],[Cid_CodIBGE])
) 
go

Alter table [Cidades] add constraint [Ak_Cidades_01] unique ([Cid_CodIBGE])
go

