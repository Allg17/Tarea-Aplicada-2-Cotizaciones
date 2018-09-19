using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Utilidades
    {

        public static decimal CalcularImporte(int cantidad, decimal precio)
        {
            decimal Cantidad = Convert.ToDecimal(cantidad);

            return Cantidad * precio;
        }
    }
}
