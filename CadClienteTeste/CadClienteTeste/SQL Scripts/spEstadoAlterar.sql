-- =============================================
-- Author:  Ednilson Luciano Cipolla
-- Create Date: 01/05/2019
-- Description: Procedimento de alteração na tabela de estados
-- =============================================
CREATE PROCEDURE spEstadoAlterar
(
	@UF as Char(2)
	, @Nome as varchar(100)
)
AS
BEGIN

    Update Estados set 
		Est_Nome = @Nome
	Where Est_UF = @UF
    
END
GO
