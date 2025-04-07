using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ISPF.AppGestion;
using ISPF.Models;

namespace ISPF.Controllers
{
    public class DepartamentoController : Controller
    {
        // GET: api/Departamento
        public ActionResult Index()
        {
            departamentoGestion depG = new departamentoGestion();
            ViewBag.data = depG.mostrarDepartamentos("");
            return View();
        }

        // GET: api/Departamento/5
        [System.Web.Http.HttpPost]
        public ActionResult insertar(DepartamentoModelo dep)
        {
           departamentoGestion depG = new departamentoGestion();
            depG.insertar(dep);
            return View();
        }

        // POST: api/Departamento
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Departamento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Departamento/5
        public void Delete(int id)
        {
        }
    }
}
