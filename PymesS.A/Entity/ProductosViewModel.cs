using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymesS.A.Entity
{
    public class ProductosViewModel
    {
        private DB_PymesEntities contexto;

        public ProductosViewModel()
        {
            contexto = new DB_PymesEntities();
            
        }
        

        private DB_PymesEntities db = new DB_PymesEntities();

        public void actualizar_mo()
        {

           var pagomanoobra = db.PagoManoObra.ToList();
            foreach(var n in pagomanoobra)
            {
                n.total = n.HorasTrabjadas * n.PagoxHora;
            }
            db.SaveChanges();
        }

        

        //Get: /PagoMo/
    }

}
