-- =============================================
-- Author:  Ednilson Luciano Cipolla
-- Create Date: 01/05/2019
-- Description: Procedimento de alteração na tabela de cidades
-- =============================================
CREATE PROCEDURE spCidadesAlterar
(
	@UF as Char(2)
	, @Cid_CodIBGE as char(7)
	, @Cid_Nome as Varchar(100)
)
AS
BEGIN

    Update Cidades set 
		Est_UF = @UF
		, Cid_Nome = @Cid_Nome
	Where  Cid_CodIBGE = @Cid_CodIBGE
    
END
GO
