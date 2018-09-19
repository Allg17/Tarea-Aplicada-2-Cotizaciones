using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Cotizaciones> Cotizaciones { get; set; }
        public DbSet<CotizacionesDetalle> Detalle { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        

        public Contexto() : base("ConStr")
        {
        }
    }
}
