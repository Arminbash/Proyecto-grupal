CREATE PROCEDURE [dbo].[sp_Prodcuto_buscar_ya]
as
begin
set NOCOUNT ON;

delete Producto
where NombreProducto like NombreProducto;
end