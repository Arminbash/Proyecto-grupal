using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Entity
{
   public  class buscarActivos
    {
        public Producto GetactivoByACTIVO(bool activo)
        {
            var contexto = new DB_PymesEntities();
            return contexto.buscarActivos1(activo).FirstOrDefault();
        }
    }
}
