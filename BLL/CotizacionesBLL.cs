using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CotizacionesBLL : RepositorioBase<Cotizaciones>
    {
        public override bool Guardar(Cotizaciones entity)
        {
            bool paso = false, pasoArticulo = false;
            _contexto = new DAL.Contexto();
            try
            {
                foreach (var item in entity.CotizacionDetalle)
                {
                    if (AgregarArticulosCotizados(item.ArticuloID, item.Cantidad))
                        pasoArticulo = true;
                }
                if (pasoArticulo && base.Guardar(entity))
                    paso = true;

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool AgregarArticulosCotizados(int articuloID, int cantidad)
        {
            bool paso = false;
            RepositorioBase<Articulo> _contexto = new BLL.RepositorioBase<Articulo>();
            Articulo articulo = _contexto.Buscar(articuloID);
            articulo.ArticulosCotizados += cantidad;

            if (_contexto.Modificar(articulo))
                paso = true;


            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false, pasoArticulo = false;
            _contexto = new Contexto();
            try
            {
                Cotizaciones cotizaciones = _contexto.Cotizaciones.Find(id);
                foreach (var item in cotizaciones.CotizacionDetalle)
                {
                    if (EliminarArticuloCotizado(item.ArticuloID, item.Cantidad))
                        pasoArticulo = true;
                }

                if (pasoArticulo && base.Eliminar(id))
                    paso = true;

            }
            catch (Exception)
            {

                throw;
            }


            return paso;
        }

        private bool EliminarArticuloCotizado(int articuloID, int cantidad)
        {
            bool paso = false;
            RepositorioBase<Articulo> _contexto = new BLL.RepositorioBase<Articulo>();
            Articulo articulo = _contexto.Buscar(articuloID);
            articulo.ArticulosCotizados -= cantidad;

            if (_contexto.Modificar(articulo))
                paso = true;


            return paso;
        }

        public override bool Modificar(Cotizaciones entity)
        {
            bool paso = false, pasoArticulo = false;
            _contexto = new Contexto();
            RepositorioBase<CotizacionesDetalle> Articulo = new BLL.RepositorioBase<CotizacionesDetalle>();
            try
            {
                // modificando la cantidad cotizada del articulo
                foreach (var item in entity.CotizacionDetalle)
                {
                    if (item.ID > 0 && EliminarArticuloCotizado(item.ArticuloID, item.Cantidad))
                        if (AgregarArticulosCotizados(item.ArticuloID, item.Cantidad))
                            pasoArticulo = true;
                }
                //buscando en base de datos el detalle
                var ListaBaseDatos = Articulo.GetList(x => x.IdCotizaciones.Equals(entity.IdCotizaciones));

                //Siempre se verifica si hay algun detalle que eliminar
                foreach (var item in ListaBaseDatos)
                {
                    if (!entity.CotizacionDetalle.Exists(x => x.ID.Equals(item.ID)))
                    {
                        EliminarArticuloCotizado(item.ArticuloID, item.Cantidad); // si hay un detalle que eliminar rebaja de articulos cotizados la cantidad
                        _contexto.Entry(item).State = EntityState.Deleted;
                    }
                }
                //Para Agregar o modificar un detalle
                foreach (var item in entity.CotizacionDetalle)
                {
                    var estado = item.ID > 0 ? EntityState.Modified : EntityState.Added;
                    _contexto.Entry(item).State = estado;
                    if (item.ID.Equals(0))
                        AgregarArticulosCotizados(item.ArticuloID, item.Cantidad); // si el detalle es igual a 0 entonces agrega la cantidad a el articulo.articuloCotizado
                    _contexto.SaveChanges();
                }

                // finalmente modificando la cotizacion
                if (pasoArticulo && base.Modificar(entity))
                    paso = true;

            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }
    }


}
