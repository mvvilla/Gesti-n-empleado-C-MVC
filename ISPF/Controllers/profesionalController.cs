using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ISPF.AppGestion;
using ISPF.Models;

namespace ISPF.Controllers
{
    public class profesionalController : ApiController
    {
        // GET: api/profesional
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/profesional/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/profesional
        public String Post([FromBody]ProfesionalEmModelo value)
        {
            datosproGestion dpG = new datosproGestion();
            String msj=dpG.insertar(value);
            return msj;
        }

        // PUT: api/profesional/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/profesional/5
        public void Delete(int id)
        {
        }
    }
}
