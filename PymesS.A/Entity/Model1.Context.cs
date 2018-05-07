﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DB_PymesEntities : DbContext
    {
        public DB_PymesEntities()
            : base("name=DB_PymesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<CostoProduccion> CostoProduccion { get; set; }
        public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }
        public virtual DbSet<EntradaMateriaPrima> EntradaMateriaPrima { get; set; }
        public virtual DbSet<EntradaProducto> EntradaProducto { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<PagoManoObra> PagoManoObra { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<TipoInventario> TipoInventario { get; set; }
        public virtual DbSet<TipoPersona> TipoPersona { get; set; }
        public virtual DbSet<TipoProducto> TipoProducto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }
    
        public virtual ObjectResult<buscarActivos_Result> buscarActivos(Nullable<bool> activo)
        {
            var activoParameter = activo.HasValue ?
                new ObjectParameter("activo", activo) :
                new ObjectParameter("activo", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<buscarActivos_Result>("buscarActivos", activoParameter);
        }
    
        public virtual ObjectResult<sbuscar_producto_Result> sbuscar_producto(string textobuscar)
        {
            var textobuscarParameter = textobuscar != null ?
                new ObjectParameter("textobuscar", textobuscar) :
                new ObjectParameter("textobuscar", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sbuscar_producto_Result>("sbuscar_producto", textobuscarParameter);
        }
    
        public virtual ObjectResult<Producto> buscarActivos1(Nullable<bool> activo)
        {
            var activoParameter = activo.HasValue ?
                new ObjectParameter("activo", activo) :
                new ObjectParameter("activo", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Producto>("buscarActivos1", activoParameter);
        }
    
        public virtual ObjectResult<Producto> buscarActivos1(Nullable<bool> activo, MergeOption mergeOption)
        {
            var activoParameter = activo.HasValue ?
                new ObjectParameter("activo", activo) :
                new ObjectParameter("activo", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Producto>("buscarActivos1", mergeOption, activoParameter);
        }
    
        public virtual ObjectResult<filtracedula_Result> filtracedula(string cedula)
        {
            var cedulaParameter = cedula != null ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<filtracedula_Result>("filtracedula", cedulaParameter);
        }
    
        public virtual int sp_Borrar_persona_Menores()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Borrar_persona_Menores");
        }
    
        public virtual ObjectResult<sp_persona_Mayor_De_cedula_Result> sp_persona_Mayor_De_cedula(string cedula)
        {
            var cedulaParameter = cedula != null ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_persona_Mayor_De_cedula_Result>("sp_persona_Mayor_De_cedula", cedulaParameter);
        }
    
        public virtual ObjectResult<sp_persona_por_cedula_Result> sp_persona_por_cedula(string cedula)
        {
            var cedulaParameter = cedula != null ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_persona_por_cedula_Result>("sp_persona_por_cedula", cedulaParameter);
        }
    
        public virtual int sp_Prodcuto_buscar_ya()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Prodcuto_buscar_ya");
        }
    
        public virtual ObjectResult<sp_producto_buscar_Result> sp_producto_buscar(string nombreProducto)
        {
            var nombreProductoParameter = nombreProducto != null ?
                new ObjectParameter("NombreProducto", nombreProducto) :
                new ObjectParameter("NombreProducto", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_producto_buscar_Result>("sp_producto_buscar", nombreProductoParameter);
        }
    
        public virtual ObjectResult<Producto> sp_producto_buscar1(string nombreProducto)
        {
            var nombreProductoParameter = nombreProducto != null ?
                new ObjectParameter("NombreProducto", nombreProducto) :
                new ObjectParameter("NombreProducto", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Producto>("sp_producto_buscar1", nombreProductoParameter);
        }
    
        public virtual ObjectResult<Producto> sp_producto_buscar1(string nombreProducto, MergeOption mergeOption)
        {
            var nombreProductoParameter = nombreProducto != null ?
                new ObjectParameter("NombreProducto", nombreProducto) :
                new ObjectParameter("NombreProducto", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Producto>("sp_producto_buscar1", mergeOption, nombreProductoParameter);
        }
    
        public virtual ObjectResult<producto_buscar_Result> producto_buscar(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<producto_buscar_Result>("producto_buscar", idProductoParameter);
        }
    
        public virtual ObjectResult<producto_buscar_Result> producto_buscar1(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<producto_buscar_Result>("producto_buscar1", idProductoParameter);
        }
    
        public virtual ObjectResult<Producto> producto_buscar2(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Producto>("producto_buscar2", idProductoParameter);
        }
    
        public virtual ObjectResult<Producto> producto_buscar2(Nullable<int> idProducto, MergeOption mergeOption)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Producto>("producto_buscar2", mergeOption, idProductoParameter);
        }
    }
}
