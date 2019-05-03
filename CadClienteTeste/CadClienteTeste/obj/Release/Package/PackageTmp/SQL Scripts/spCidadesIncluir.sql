-- =============================================
-- Author:  Ednilson Luciano Cipolla
-- Create Date: 01/05/2019
-- Description: Procedimento de inclusão na tabela de cidades
-- =============================================
CREATE PROCEDURE spCidadesIncluir
(
	@UF as Char(2)
	, @Cid_CodIBGE as char(7)
	, @Cid_Nome as Varchar(100)
)
AS
BEGIN

    Insert into Cidades (
		Est_UF
		, Cid_CodIBGE
		, Cid_Nome
	) values (
		@UF
		, @Cid_CodIBGE
		, @Cid_Nome
	)
    
END
GO
