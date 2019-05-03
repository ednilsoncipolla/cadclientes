-- =============================================
-- Author:  Ednilson Luciano Cipolla
-- Create Date: 01/05/2019
-- Description: View de recuperação das informações do cadastro de Cidades
-- =============================================
CREATE VIEW vwCidades
AS
	SELECT
		Est_UF
		, Cid_CodIBGE
		, Cid_Nome
	FROM Cidades
GO
