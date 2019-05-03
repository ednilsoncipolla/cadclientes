-- =============================================
-- Author:  Ednilson Luciano Cipolla
-- Create Date: 01/05/2019
-- Description: Procedimento de Exclusão na tabela de clientes
-- =============================================
CREATE PROCEDURE spClientesExcluir
(
	@Cli_Id as int
)
AS
BEGIN

    Delete from Cidades 
	Where Cli_Id = @Cli_Id
    
END
GO
