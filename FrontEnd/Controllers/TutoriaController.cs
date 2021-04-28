using FrontEnd.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class TutoriaController : Controller
    {
        private readonly IWebHostEnvironment _iwebHostEnvironment;

        public TutoriaController(IWebHostEnvironment webHostEnvironment)
        {
            _iwebHostEnvironment = webHostEnvironment;
        }

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

                serviceObj = new ServiceRepository();
                response = serviceObj.GetResponse("api/Calificacion/getall");
                response.EnsureSuccessStatusCode();
                //List<Models.DistritoViewModel> categories = new List<Models.DistritoViewModel>();
                content = response.Content.ReadAsStringAsync().Result;
                List<Models.CalificacionTutoriaViewModel> calificaciones = JsonConvert.DeserializeObject<List<Models.CalificacionTutoriaViewModel>>(content);


                foreach (var item in tutoria)
                {
                    response = serviceObj.GetResponse("api/Curso/?id=" + item.IdCurso.ToString());
                    response.EnsureSuccessStatusCode();
                    item.Curso = response.Content.ReadAsAsync<Models.CursoViewModel>().Result;

                    response = serviceObj.GetResponse("api/Institucion/?id=" + item.IdInstitucion.ToString());
                    response.EnsureSuccessStatusCode();
                    item.Institucion = response.Content.ReadAsAsync<Models.InstitucionViewModel>().Result;

                    decimal? sum = 0;
                    var total = 0;
                    decimal? prom = 0;
                    foreach (var calif in calificaciones)
                    {
                        if (item.IdTutoriaCursos == calif.IdTutoriaCursos)
                        {
                            sum += calif.Calificacion;
                            total += 1;
                        }
                    }

                    if (sum != 0)
                    {
                        prom = sum / total;

                        item.calificaciones = prom;
                    }
                }

                ViewBag.Title = "All Tutorias";
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
            Models.TutoriaViewModel tutoria = new Models.TutoriaViewModel();

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Institucion/getall");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            tutoria.Institucions = JsonConvert.DeserializeObject<List<Models.InstitucionViewModel>>(content);

            response = serviceObj.GetResponse("api/Curso/getall");
            response.EnsureSuccessStatusCode();
            content = response.Content.ReadAsStringAsync().Result;
            tutoria.Cursos = JsonConvert.DeserializeObject<List<Models.CursoViewModel>>(content);


            return View(tutoria);
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

            #region('instituciones')
            Models.InstitucionViewModel institucion;
            List<Models.InstitucionViewModel> institucions = new List<Models.InstitucionViewModel>();
            response = serviceObj.GetResponse("api/Institucion/getall");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            institucions = JsonConvert.DeserializeObject<List<Models.InstitucionViewModel>>(content);
            
            response = serviceObj.GetResponse("api/Institucion/?id=" + tutoriaViewModel.IdInstitucion.ToString());
            response.EnsureSuccessStatusCode();
            institucion = response.Content.ReadAsAsync<Models.InstitucionViewModel>().Result;

            institucions.Remove(institucion);
            institucions.Insert(0, institucion);
            institucions.Remove(institucion);
            tutoriaViewModel.Institucions = institucions;
            #endregion

            #region('cursos')
            Models.CursoViewModel curso;
            List<Models.CursoViewModel> cursos = new List<Models.CursoViewModel>();
            response = serviceObj.GetResponse("api/Curso/getall");
            response.EnsureSuccessStatusCode();
            content = response.Content.ReadAsStringAsync().Result;
            cursos = JsonConvert.DeserializeObject<List<Models.CursoViewModel>>(content);

            response = serviceObj.GetResponse("api/Curso/?id=" + tutoriaViewModel.IdCurso.ToString());
            response.EnsureSuccessStatusCode();
            curso = response.Content.ReadAsAsync<Models.CursoViewModel>().Result;

            cursos.Remove(curso);
            cursos.Insert(0, curso);
            cursos.Remove(curso);
            tutoriaViewModel.Cursos = cursos;
            #endregion

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








        [HttpGet]
        public ActionResult Archivo(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Tutoria/getall");
            response.EnsureSuccessStatusCode();
            //List<Models.DistritoViewModel> categories = new List<Models.DistritoViewModel>();
            var content = response.Content.ReadAsStringAsync().Result;
            List<Models.TutoriaViewModel> tutoria = JsonConvert.DeserializeObject<List<Models.TutoriaViewModel>>(content);

            foreach (var item in tutoria)
            {
                response = serviceObj.GetResponse("api/Curso/?id=" + item.IdCurso.ToString());
                response.EnsureSuccessStatusCode();
                item.Curso = response.Content.ReadAsAsync<Models.CursoViewModel>().Result;

                response = serviceObj.GetResponse("api/Institucion/?id=" + item.IdInstitucion.ToString());
                response.EnsureSuccessStatusCode();
                item.Institucion = response.Content.ReadAsAsync<Models.InstitucionViewModel>().Result;
            }

            var tutoriaArchivo = tutoria.SingleOrDefault(x => x.IdTutoriaCursos == id);


            return View(tutoriaArchivo);
        }

        [HttpPost]
        public ActionResult Archivo(IFormCollection valores)
        {
            var r = valores.Files.First();

            string folder = "files/";
            folder += r.FileName;
            string serverFolder =Path.Combine(_iwebHostEnvironment.WebRootPath, folder);
            r.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            Models.MaterialViewModel material = new Models.MaterialViewModel() {
                IdTutoriaCursos = int.Parse(valores["IdTutoriaCursos"]),
                DireccionArchivo = r.FileName
            };

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Material/agregar", material);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }





        public async Task<IActionResult> Download(IFormCollection valores)
        {
            var r = valores["archivo"];

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/files", r);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "text/plain", Path.GetFileName(path));
        }
    }
}
