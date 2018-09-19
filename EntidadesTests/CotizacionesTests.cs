using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace Entidades.Tests
{
    [TestClass()]
    public class CotizacionesTests
    {
        Cotizaciones cotizaciones = new Cotizaciones();

        //LlenaClase
        private Cotizaciones GetCotizaciones()
        {
            cotizaciones.IdCotizaciones = 2;
            cotizaciones.Comentario = "Prueba modificada";
            cotizaciones.Fecha = DateTime.Now;

            foreach (var item in GetDetalle())
            {
                cotizaciones.Monto += item.Importe;
            }
            return cotizaciones;
        }

        //LlenaDetalle
        private List<CotizacionesDetalle> GetDetalle()
        {
            RepositorioBase<Articulo> _contexto = new BLL.RepositorioBase<Articulo>();
            var precio = _contexto.Buscar(1).Precio;
            cotizaciones.AgregarDetalle(0, 0, 1, 15, precio, BLL.Utilidades.CalcularImporte(10, precio));

            return cotizaciones.CotizacionDetalle;
        }

        [TestMethod()]
        public void GuardarCotizaciones()
        {
            CotizacionesBLL cotizaciones = new CotizacionesBLL();
            Assert.IsTrue(cotizaciones.Guardar(GetCotizaciones()));
        }

        [TestMethod()]
        public void EliminarCotizacion()
        {
            CotizacionesBLL cotizaciones = new CotizacionesBLL();
            Assert.IsTrue(cotizaciones.Eliminar(3));
        }

        private Cotizaciones GetCotizacionesModificar()
        {
            RepositorioBase<Articulo> _contexto = new BLL.RepositorioBase<Articulo>();

            CotizacionesBLL quotation = new CotizacionesBLL();

            cotizaciones.IdCotizaciones = 2;
            cotizaciones.Comentario = "Prueba modificada again";
            cotizaciones.Fecha = DateTime.Now;

            var precio = _contexto.Buscar(1).Precio;

            //Buscando la Cotizacion y igualando el detalle
            cotizaciones.CotizacionDetalle = quotation.Buscar(2).CotizacionDetalle;

            //Agregando Otro Elemento a la lista 
            cotizaciones.AgregarDetalle(0, cotizaciones.IdCotizaciones, 1, 15, precio, BLL.Utilidades.CalcularImporte(15, precio));

            for (int x = 0; x < cotizaciones.CotizacionDetalle.Count(); ++x)
            {
                cotizaciones.Monto  += BLL.Utilidades.CalcularImporte(cotizaciones.CotizacionDetalle.ElementAt(x).Cantidad, cotizaciones.CotizacionDetalle.ElementAt(x).Precio);

            }

            //** Para probar Elimiando es este codigo de abajo**
            //cotizaciones.CotizacionDetalle.Remove(cotizaciones.CotizacionDetalle.ElementAt(0));

            return cotizaciones;
        }

        [TestMethod()]
        public void ModificarCotizacion()
        {
            CotizacionesBLL quotation = new CotizacionesBLL();
            Assert.IsTrue(quotation.Modificar(GetCotizacionesModificar()));
        }
    }
}