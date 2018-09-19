using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Articulo
    {
        [Key]
        public int ArticuloID { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int ArticulosCotizados { get; set; }

        public Articulo(int articuloID, string descripcion, decimal precio, int articulosCotizados)
        {
            this.ArticuloID = articuloID;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.ArticulosCotizados = articulosCotizados;
        }

        public Articulo()
        {
            this.ArticuloID = 0;
            this.Descripcion = string.Empty;
            this.Precio = 0;
            this.ArticulosCotizados = 0;
        }
    }
}
