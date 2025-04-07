using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ISPF.AppGestion;
using ISPF.Models;
using System.Collections;
using CrystalDecisions.CrystalReports.Engine;
using ISPF.dataSet;
using System.IO;
using MySql.Data.MySqlClient;

namespace ISPF.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: api/Empleado
        public ActionResult Index() {

            empleadoGestion emple = new empleadoGestion();
            ViewBag.data = emple.mostrarEmpleados("");
            return View();
        }

        [System.Web.Http.HttpPost]
        public ActionResult insertar(EmpleadoModelo emple)
        {
            empleadoGestion empleG = new empleadoGestion();
            empleG.insertar(emple);
            return View("Index");
        }

        [HttpPost]
        public ActionResult insertarBene(BeneficiarioModelo bene)
        {
            beneficiarioGestion empleG = new beneficiarioGestion();
            empleG.insertar(bene);
            return View("Index");
        }

        public ActionResult insertarBene()
        {
            return View();
        }
        [HttpPost]
        public ActionResult insertarProf(ProfesionalEmModelo prof)
        {
            datosproGestion empleG = new datosproGestion();
            empleG.insertar(prof);
            return View("Index");
        }
        public ActionResult insertarProf(string cod)
        {
   
            return View();
        }

        public JsonResult buscarDepa()
        {
            departamentoGestion depG = new departamentoGestion();
            ArrayList data = depG.mostrarDepartamentos("");
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult buscarEmple(string cod)
        {
            empleadoGestion emple = new empleadoGestion();
            ViewBag.data = emple.obtenerEmpleadoDetalle(cod);
            return View(ViewBag.data);
        }

        public JsonResult buscarPuesto(String cod) {
            PuestoGestion pu = new PuestoGestion();
            ArrayList data = pu.mostrarPuestosD(cod);
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        public JsonResult buscarUniversidad(String cod)
        {
            universidadGestion uni = new universidadGestion();
            ArrayList data = uni.mostrarUniversidad("");
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult buscarUni()
        {
            universidadGestion u = new universidadGestion();
            ArrayList data = u.mostrarUniversidad("");
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult buscarProf(string cod)
        {
            datosproGestion un = new datosproGestion();
            ArrayList data = un.obtenerProf(cod);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult buscarBene(string cod)
        {
            beneficiarioGestion be = new beneficiarioGestion();
            ArrayList data = be.obtenerBeneficiario(cod);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult exportar(string dato) {
            ReportDocument rptr = new ReportDocument();
            rptr.Load(Server.MapPath("~/reporte/empleadoReport.rpt"));
            empleadoGestion empleG = new empleadoGestion();
            MySqlDataAdapter md;
            md = empleG.reporte(dato);
            empleadoDataSet1 eDs = new empleadoDataSet1();
            md.Fill(eDs, "fullEmpleado");
            rptr.SetDataSource(eDs);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rptr.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0,SeekOrigin.Begin);
            return File(stream, "application/pdf", "Ficha Empleado.pdf");
        }
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Empleado/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Empleado
        public void Post([System.Web.Http.FromBody]string value)
        {
        }

        // PUT: api/Empleado/5
        public void Put(int id, [System.Web.Http.FromBody]string value)
        {
        }

        // DELETE: api/Empleado/5
        public void Delete(int id)
        {
        }
    }
}
