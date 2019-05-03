-- =============================================
-- Author:  Ednilson Luciano Cipolla
-- Create Date: 01/05/2019
-- Description: Procedimento de inclusão na tabela de estados
-- =============================================
CREATE PROCEDURE spEstadoIncluir
(
	@UF as Char(2)
	, @Nome as varchar(100)
)
AS
BEGIN

    Insert into Estados (
		Est_UF
		, Est_Nome
	) values (
		@UF
		, @Nome
	)
    
END
GO
