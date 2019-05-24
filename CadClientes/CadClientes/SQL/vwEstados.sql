-- =============================================
-- Author:  Ednilson Luciano Cipolla
-- Create Date: 01/05/2019
-- Description: View de recuperação das informações do cadastro de estados
-- =============================================
CREATE VIEW vwEstados
AS
	SELECT
		Est_UF
		, Est_Nome
	FROM Estados
GO

