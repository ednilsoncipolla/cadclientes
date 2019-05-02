-- =============================================
-- Author:  Ednilson Luciano Cipolla
-- Create Date: 01/05/2019
-- Description: Procedimento de inclusão na tabela de clientes
-- =============================================
CREATE PROCEDURE spClientesIncluir
(
	@UF as Char(2)
	, @Cid_CodIBGE as char(7)
	, @Cli_Nome as Varchar(100)
	, @Cli_Bairro as Varchar(100)
	, @Cli_EndEndereço as Varchar(100)
	, @Cli_EndNumero as int 
	, @Cli_EndComplemento as Varchar(100)
	, @Cli_Email as Varchar(100)
	, @Cli_TelResidencial as Varchar(100)
	, @Cli_TelCelular as Varchar(100)
)
AS
BEGIN

    Insert into Cidades (
		Est_UF
		, Cid_CodIBGE
		, Cli_Nome
		, Cli_Bairro
		, Cli_EndEndereço
		, Cli_EndNumero
		, Cli_EndComplemento
		, Cli_Email
		, Cli_TelResidencial
		, Cli_TelCelular
	) values (
		@UF
		, @Cid_CodIBGE
		, @Cli_Nome
		, @Cli_Bairro
		, @Cli_EndEndereço
		, @Cli_EndNumero
		, @Cli_EndComplemento
		, @Cli_Email
		, @Cli_TelResidencial
		, @Cli_TelCelular
	)
    
END
GO
