using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ISPF.Models;
using ISPF.AppGestion;
using System.Collections;

namespace ISPF.Controllers
{
    public class PuestoController : Controller
    {
        // GET: api/Puesto
        public ActionResult Index()
        {
            PuestoGestion pu = new PuestoGestion();
            ViewBag.data = pu.mostrarPuestos("");
            return View();
        }

        public JsonResult buscarDepa() {
            departamentoGestion depG = new departamentoGestion();
            ArrayList data = depG.mostrarDepartamentos("");
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public ActionResult insertar(PuestoModelo pu) {
            PuestoGestion puG = new PuestoGestion();
            puG.insertar(pu);
            return View();

        }

        // GET: api/Puesto/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Puesto
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Puesto/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Puesto/5
        public void Delete(int id)
        {
        }
    }
}
