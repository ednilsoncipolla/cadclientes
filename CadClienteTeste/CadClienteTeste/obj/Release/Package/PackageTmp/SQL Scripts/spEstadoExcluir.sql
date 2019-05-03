-- =============================================
-- Author:  Ednilson Luciano Cipolla
-- Create Date: 01/05/2019
-- Description: Procedimento de exclusão na tabela de estados
-- =============================================
CREATE PROCEDURE spEstadoExcluir
(
	@UF as Char(2)
)
AS
BEGIN

    Delete Estados  
	Where Est_UF = @UF
    
END
GO

