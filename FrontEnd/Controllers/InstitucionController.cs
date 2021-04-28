using FrontEnd.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    [Authorize(Roles = "Administrador, Profesor")]
    public class InstitucionController : Controller
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
                List<Models.InstitucionViewModel> institucions = JsonConvert.DeserializeObject<List<Models.InstitucionViewModel>>(content);

               // ViewBag.Title = "All Institucions";
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
        public ActionResult Create(Models.InstitucionViewModel institucion)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Institucion/agregar", institucion);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Details(int id)
        {

            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Institucion/?id=" + id.ToString());
                response.EnsureSuccessStatusCode();
                Models.InstitucionViewModel institucionViewModel = response.Content.ReadAsAsync<Models.InstitucionViewModel>().Result;
                //ViewBag.Title = "All Products";
                return View(institucionViewModel);
            }
            catch (Exception err) {
                return RedirectToAction("Index",err);
            }
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Institucion/?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.InstitucionViewModel institucionViewModel = response.Content.ReadAsAsync<Models.InstitucionViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(institucionViewModel);
        }


        [HttpPost]
        public ActionResult Edit(Models.InstitucionViewModel institucion)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Institucion/actualizar", institucion);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Institucion/?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.InstitucionViewModel institucionViewModel = response.Content.ReadAsAsync<Models.InstitucionViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(institucionViewModel);
        }


        [HttpPost]
        public ActionResult Delete(Models.InstitucionViewModel institucion)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Institucion/eliminar", institucion);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
    }
}
