-- =============================================
-- Author:  Ednilson Luciano Cipolla
-- Create Date: 01/05/2019
-- Description: View de recuperação das informações do cadastro de Clientes
-- =============================================
CREATE VIEW vwClientes
AS
	SELECT
		Est_UF
		, Cid_CodIBGE
		, Cli_Id
		, Cli_Nome
		, Cli_Bairro
		, Cli_EndEndereço
		, Cli_EndNumero
		, Cli_EndComplemento
		, Cli_Email
		, Cli_TelResidencial
		, Cli_TelCelular
	FROM Clientes
GO
