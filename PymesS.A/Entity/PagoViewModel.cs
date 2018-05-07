using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PagoViewModel
    {
        private DB_PymesEntities db = new DB_PymesEntities();

        public void actualizar_mo()
        {
            var pagomanoobra = db.PagoManoObra.ToList();
            foreach (var n in pagomanoobra)
            {
                n.total = n.HorasTrabjadas * n.PagoxHora;
            }
            db.SaveChanges();
        }
    }
}
