namespace PymesS.A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Creando_SP : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("sp_persona_por_cedula", x => new { Cedula = x.String() },
                @"SELECT Nombre, Cedula FROM Persona
                 WHERE Cedula =@Cedula");

            CreateStoredProcedure("sp_persona_Mayor_De_cedula", x => new { Cedula = x.String(006)},
               @"SELECT Nombre, Cedula FROM Persona
                 WHERE Cedula =@Cedula");

            

            Sql(RecursosSQL.Crear_sp_Borrar_persona_Menores);


            //CreateStoredProcedure("sp_Producto_Por_Activo", x => new { activo = x.Boolean(true)}, 
            //    @"SELECT activo FROM Producto
            //      WHERE activo =@activo");

        }

        

        public override void Down()
        {
            DropStoredProcedure("sp_persona_por_cedula");
            DropStoredProcedure("sp_persona_Mayor_De_cedula");
            Sql(RecursosSQL.Borra_sp_Borrar_persona_Menores);
        }
    }
}
