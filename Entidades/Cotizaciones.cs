using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cotizaciones
    {
        [Key]
        public int IdCotizaciones { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public decimal Monto { get; set; }
        public virtual List<CotizacionesDetalle> CotizacionDetalle { get; set; }

        public Cotizaciones()
        {
            this.CotizacionDetalle = new List<CotizacionesDetalle>();
        }

        public void AgregarDetalle(int id,int idCotizaciones, int articuloid,int cantidad, decimal precio, decimal importe)
        {
            this.CotizacionDetalle.Add(new CotizacionesDetalle(id,idCotizaciones,articuloid,cantidad,precio,importe));
        }
    }
}
