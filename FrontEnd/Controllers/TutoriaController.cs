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
    public class TutoriaController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Tutoria/getall");
                response.EnsureSuccessStatusCode();
                //List<Models.DistritoViewModel> categories = new List<Models.DistritoViewModel>();
                var content = response.Content.ReadAsStringAsync().Result;
                List<Models.TutoriaViewModel> tutoria = JsonConvert.DeserializeObject<List<Models.TutoriaViewModel>>(content);

                ViewBag.Title = "All Institucions";
                return View(tutoria);
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
        public ActionResult Create(Models.TutoriaViewModel tutoria)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Tutoria/agregar", tutoria);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Details(int id)
        {

            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Tutoria/?id=" + id.ToString());
                response.EnsureSuccessStatusCode();
                Models.TutoriaViewModel tutoriaViewModel = response.Content.ReadAsAsync<Models.TutoriaViewModel>().Result;
                //ViewBag.Title = "All Products";
                return View(tutoriaViewModel);
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
            HttpResponseMessage response = serviceObj.GetResponse("api/Tutoria/?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.TutoriaViewModel tutoriaViewModel = response.Content.ReadAsAsync<Models.TutoriaViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(tutoriaViewModel);
        }


        [HttpPost]
        public ActionResult Edit(Models.TutoriaViewModel tutoria)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Tutoria/actualizar", tutoria);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Tutoria/?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.TutoriaViewModel tutoriaViewModel = response.Content.ReadAsAsync<Models.TutoriaViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(tutoriaViewModel);
        }


        [HttpPost]
        public ActionResult Delete(Models.TutoriaViewModel tutoria)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Tutoria/eliminar", tutoria);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
    }
}
