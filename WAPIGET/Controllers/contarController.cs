using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WAPIGET.Controllers
{
    public class contarController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<ViewModel.conteoViewModel> lst = new List<ViewModel.conteoViewModel>();

            using (Models.DBAPIEntities dbase = new Models.DBAPIEntities())
            {
                lst = (from d in dbase.VEHICULO
                       select new ViewModel.conteoViewModel
                       {
                           Id = d.ID,
                           Marca = d.MARCA,
                           Precio = d.PRECIO,
                           Condicion = d.CONDICION,
                           Estatus = d.ESTATUS,
                           Detalles = d.DETALLES,
                           Fotos = d.FOTOS,
                           Modelo = d.MODELO,
                           nYear = d.nYEAR

                       }).ToList();
            }

            return Ok(lst);
        }

        [HttpPost]
        public IHttpActionResult Add(Models.Request.conteoRequest model)
        {
            using (Models.DBAPIEntities dbase = new Models.DBAPIEntities())
            {
                var oConteo = new Models.VEHICULO();

                oConteo.MARCA = model.Marca;
                oConteo.PRECIO = model.Precio;
                oConteo.CONDICION = model.Condicion;
                oConteo.ESTATUS = model.Estatus;
                oConteo.DETALLES = model.Detalles;
                oConteo.FOTOS = model.Fotos;
                oConteo.MODELO = model.Modelo;
                oConteo.nYEAR = model.nYear;

                dbase.VEHICULO.Add(oConteo);
                dbase.SaveChanges();
            }

            return Ok("Registro agregado con un modelo");
        }

        [HttpPut]
        public IHttpActionResult Put(ViewModel.conteoViewModel model)
        {
            using (var dbase = new Models.DBAPIEntities())
            {
                var oConteo = dbase.VEHICULO.Find(model.Id); // select * from invconteo where id = 1
                oConteo.MARCA = model.Marca;
                oConteo.PRECIO = model.Precio;
                oConteo.CONDICION = model.Condicion;
                oConteo.ESTATUS = model.Estatus;
                oConteo.DETALLES = model.Detalles;
                oConteo.FOTOS = model.Fotos;
                oConteo.MODELO = model.Modelo;
                oConteo.nYEAR = model.nYear;

                dbase.Entry(oConteo).State = System.Data.Entity.EntityState.Modified;
                dbase.SaveChanges();
            }

            return Ok("Registro actualizado :");
        }

        [HttpDelete]
        public IHttpActionResult Del(int Id)
        {
            using (var dbase = new Models.DBAPIEntities())
            {
                var oConteo = dbase.VEHICULO.Find(Id);
                dbase.VEHICULO.Remove(oConteo);
                dbase.SaveChanges();
            }

            return Ok("Registro borrado");
        }
    }
}
