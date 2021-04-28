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
    public class CursoController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Curso/getall");
                response.EnsureSuccessStatusCode();
                //List<Models.DistritoViewModel> categories = new List<Models.DistritoViewModel>();
                var content = response.Content.ReadAsStringAsync().Result;
                List<Models.CursoViewModel> institucions = JsonConvert.DeserializeObject<List<Models.CursoViewModel>>(content);

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
        public ActionResult Create(Models.CursoViewModel curso)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Curso/agregar", curso);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Details(int id)
        {

            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Curso/?id=" + id.ToString());
                response.EnsureSuccessStatusCode();
                Models.CursoViewModel cursoViewModel = response.Content.ReadAsAsync<Models.CursoViewModel>().Result;
                //ViewBag.Title = "All Products";
                return View(cursoViewModel);
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
            Models.CursoViewModel cursoViewModel = response.Content.ReadAsAsync<Models.CursoViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(cursoViewModel);
        }


        [HttpPost]
        public ActionResult Edit(Models.CursoViewModel curso)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Curso/actualizar", curso);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Curso/?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.CursoViewModel cursoViewModel = response.Content.ReadAsAsync<Models.CursoViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(cursoViewModel);
        }


        [HttpPost]
        public ActionResult Delete(Models.CursoViewModel curso)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Curso/eliminar", curso);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
    }
}
    

