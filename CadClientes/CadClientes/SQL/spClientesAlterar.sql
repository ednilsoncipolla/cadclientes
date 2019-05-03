-- =============================================
-- Author:  Ednilson Luciano Cipolla
-- Create Date: 01/05/2019
-- Description: Procedimento de Alteração na tabela de clientes
-- =============================================
CREATE PROCEDURE spClientesAlterar
(
	@UF as Char(2)
	, @Cid_CodIBGE as char(7)
	, @Cli_Id as int
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

    Update Clientes set 
		Est_UF = @UF
		, Cid_CodIBGE = @Cid_CodIBGE
		, Cli_Nome = @Cli_Nome
		, Cli_Bairro = @Cli_Bairro
		, Cli_EndEndereço = @Cli_EndEndereço
		, Cli_EndNumero = @Cli_EndNumero
		, Cli_EndComplemento = @Cli_EndComplemento
		, Cli_Email = @Cli_Email
		, Cli_TelResidencial = @Cli_TelResidencial
		, Cli_TelCelular = @Cli_TelCelular
	Where Cli_Id = @Cli_Id
    
END
GO
