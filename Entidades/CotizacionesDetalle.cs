using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CotizacionesDetalle
    {
        [Key]
        public int ID { get; set; }
        public int IdCotizaciones { get; set; }
        public int ArticuloID { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        [NotMapped]
        public decimal Importe { get; set; }

        public CotizacionesDetalle(int iD, int cotizacionesID, int articuloID, int cantidad, decimal precio, decimal importe)
        {
            ID = iD;
            IdCotizaciones = cotizacionesID;
            ArticuloID = articuloID;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }

        public CotizacionesDetalle()
        {
            ID = 0;
            IdCotizaciones = 0;
            ArticuloID = 0;
            Cantidad = 0;
            Precio = 0;
            Importe = 0;
        }
    }
}
