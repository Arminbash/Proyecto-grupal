CREATE PROCEDURE [dbo].[sp_Borrar_persona_Menores]	

as
begin

set nocount on;

delete Persona
where Cedula < 001;
end