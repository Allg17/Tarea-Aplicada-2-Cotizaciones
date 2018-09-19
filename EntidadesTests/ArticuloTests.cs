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
    public class ArticuloTests
    {
        private Articulo GetArticulo()
        {
            Articulo articulo = new Articulo();
            articulo.ArticuloID = 0;
            articulo.ArticulosCotizados = 0;
            articulo.Descripcion = "Coca Cola";
            articulo.Precio = 25;
            return articulo;
        }


        [TestMethod()]
        public void GuardarArticuloTest()
        {
            RepositorioBase<Articulo> _contexto = new BLL.RepositorioBase<Articulo>();
            Assert.IsTrue(_contexto.Guardar(GetArticulo()));
        }

  
    }
}