using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Collections;
using ISPF.Models;
using ISPF.AppGestion;

namespace ISPF.Controllers
{
    public class BeneficiarioController : Controller
    {
        // GET: api/Beneficiario
        public ActionResult Index()
        {
            return View();
        }

        // GET: api/Beneficiario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Beneficiario
        public string Post([FromBody]BeneficiarioModelo value)
        {
            beneficiarioGestion bnG = new beneficiarioGestion();
            string msj = bnG.insertar(value);
            return msj;
        }

        // PUT: api/Beneficiario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Beneficiario/5
        public void Delete(int id)
        {
        }
    }
}
