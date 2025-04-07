using ISPF.AppGestion;
using ISPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ISPF.Controllers
{
    public class UniversidadController : Controller
    {
        // GET: api/Universidad
        public ActionResult Index()
        {
            universidadGestion uni = new universidadGestion();
            ViewBag.data = uni.mostrarUniversidad("");
            return View();
        }

        [System.Web.Http.HttpPost]
        public ActionResult insertar(UniversidadModelo un) {
            universidadGestion uni = new universidadGestion();
            uni.insertar(un);
            return View();
        }

        // GET: api/Universidad/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Universidad
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Universidad/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Universidad/5
        public void Delete(int id)
        {
        }
    }
}
