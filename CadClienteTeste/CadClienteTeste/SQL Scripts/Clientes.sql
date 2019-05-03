
Create table [Clientes]
(
	[Est_UF] Char(2) NOT NULL,
	[Cid_CodIBGE] Char(7) NOT NULL,
	[Cli_Id] Integer Identity NOT NULL,
	[Cli_Nome] Varchar(100) NOT NULL,
	[Cli_Bairro] Varchar(100) NULL,
	[Cli_EndEndereço] Varchar(100) NULL,
	[Cli_EndNumero] Integer NULL,
	[Cli_EndComplemento] Varchar(100) NULL,
	[Cli_Email] Varchar(200) NULL,
	[Cli_TelResidencial] Varchar(15) NULL,
	[Cli_TelCelular] Varchar(30) NULL,
Primary Key ([Est_UF],[Cid_CodIBGE],[Cli_Id])
) 
go

Alter table [Clientes] add constraint [Ak_Clientes_01] unique ([Cli_Id])
go

Create Index [Ix_Clientes_001] ON [Clientes] ([Cli_Nome] ) 
go

