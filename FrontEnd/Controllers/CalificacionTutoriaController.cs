using FrontEnd.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class CalificacionTutoriaController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Institucion/getall");
                response.EnsureSuccessStatusCode();
                //List<Models.DistritoViewModel> categories = new List<Models.DistritoViewModel>();
                var content = response.Content.ReadAsStringAsync().Result;
                List<Models.CalificacionTutoriaViewModel> institucions = JsonConvert.DeserializeObject<List<Models.CalificacionTutoriaViewModel>>(content);

                ViewBag.Title = "All Institucions";
                return View(institucions);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.CalificacionTutoriaViewModel calificacion)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/CalificacionTutoria/agregar", calificacion);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Details(int id)
        {

            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/CalificacionTutoria/?id=" + id.ToString());
                response.EnsureSuccessStatusCode();
                Models.CalificacionTutoriaViewModel calificacionTutoriaViewModel = response.Content.ReadAsAsync<Models.CalificacionTutoriaViewModel>().Result;
                //ViewBag.Title = "All Products";
                return View(calificacionTutoriaViewModel);
            }
            catch (Exception err)
            {
                return RedirectToAction("Index", err);
            }
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Curso/?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.CalificacionTutoriaViewModel calificacionTutoriaViewModel = response.Content.ReadAsAsync<Models.CalificacionTutoriaViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(calificacionTutoriaViewModel);
        }


        [HttpPost]
        public ActionResult Edit(Models.CalificacionTutoriaViewModel calificacion)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/CalificacionTutoria/actualizar", calificacion);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/CalificacionTutoria/?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.CalificacionTutoriaViewModel calificacionTutoriaViewModel = response.Content.ReadAsAsync<Models.CalificacionTutoriaViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(calificacionTutoriaViewModel);
        }


        [HttpPost]
        public ActionResult Delete(Models.CalificacionTutoriaViewModel calificacion)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/CalificacionTutoria/eliminar", calificacion);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
    }
}
