-- =============================================
-- Author:  Ednilson Luciano Cipolla
-- Create Date: 01/05/2019
-- Description: Procedimento de exclusão na tabela de cidades
-- =============================================
CREATE PROCEDURE spCidadesExcluir
(
	@Cid_CodIBGE as char(7)
)
AS
BEGIN

    Delete from Cidades 
	Where  Cid_CodIBGE = @Cid_CodIBGE
END
GO