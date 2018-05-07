namespace PymesS.A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creando_SPS : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("sp_producto_buscar", x => new { NombreProducto = x.String() },
                @"SELECT dbo.Producto.IdProducto, dbo.TipoProducto.NombresTipoProducto, dbo.Producto.IdTipoProducto, dbo.Producto.NombreProducto,
dbo.Producto.PrecioXUnidad, dbo.Producto.Descripcion, dbo.Producto.activo FROM dbo.TipoProducto INNER JOIN dbo.Producto ON dbo.TipoProducto.IdTipoProducto = dbo.Producto.IdTipoProducto
where dbo.Producto.NombreProducto like @NombreProducto + '%' --Alt + 39
order by dbo.Producto.IdProducto desc");

            Sql(RecursosSQL.sp_Producto_buscar_ya);
        }

        
        public override void Down()
        {
            DropStoredProcedure("sp_producto_buscar");
            Sql(RecursosSQL.sp_Borrar_Producto_Nombre);
        }
    }
}
