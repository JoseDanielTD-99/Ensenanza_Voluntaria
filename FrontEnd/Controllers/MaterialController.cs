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
    public class MaterialController : Controller
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
                List<Models.MaterialViewModel> material = JsonConvert.DeserializeObject<List<Models.MaterialViewModel>>(content);

                ViewBag.Title = "All Material";
                return View(material);
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
        public ActionResult Create(Models.MaterialViewModel material)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Institucion/agregar", material);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Details(int id)
        {

            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Material/?id=" + id.ToString());
                response.EnsureSuccessStatusCode();
                Models.MaterialViewModel materialViewModel = response.Content.ReadAsAsync<Models.MaterialViewModel>().Result;
                //ViewBag.Title = "All Products";
                return View(materialViewModel);
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
            HttpResponseMessage response = serviceObj.GetResponse("api/Material/?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.MaterialViewModel materialViewModel = response.Content.ReadAsAsync<Models.MaterialViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(materialViewModel);
        }


        [HttpPost]
        public ActionResult Edit(Models.MaterialViewModel material)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Material/actualizar", material);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Material/?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.MaterialViewModel materialViewModel = response.Content.ReadAsAsync<Models.MaterialViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(materialViewModel);
        }


        [HttpPost]
        public ActionResult Delete(Models.MaterialViewModel material)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Material/eliminar", material);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
    }
}
