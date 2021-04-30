using FrontEnd.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class EstudianteController : Controller
    {

        public IActionResult Index()
        {
            return View("~/Views/Estudiante/Index.cshtml");
        }

        public IActionResult Continentes()
        {
            return View("~/Views/Estudiante/Estudios Sociales/Continentes.cshtml");
        }


        public IActionResult Tectonismo()
        {
            return View("~/Views/Estudiante/Estudios Sociales/Tectonismo.cshtml");
        }

        public IActionResult HistoriaCR()
        {
            return View("~/Views/Estudiante/Estudios Sociales/HistoriaCostaRica.cshtml");
        }

        public IActionResult UsoSignosPuntuacion()
        {
            return View("~/Views/Estudiante/Espaniol/UsoSignosPuntuacion.cshtml");
        }

        public IActionResult UsoVyb()
        {
            return View("~/Views/Estudiante/Espaniol/UsoVyB.cshtml");
        }

        public IActionResult EstructuraOracion()
        {
            return View("~/Views/Estudiante/Espaniol/EstructuraOracion.cshtml");
        }

        public IActionResult SistemaDigestivo()
        {
            return View("~/Views/Estudiante/Ciencias/SistemaDigestivo.cshtml");
        }

        public IActionResult Esqueleto()
        {
            return View("~/Views/Estudiante/Ciencias/Esqueleto.cshtml");
        }

        public IActionResult Celula()
        {
            return View("~/Views/Estudiante/Ciencias/Celula.cshtml");
        }

        public IActionResult Suma()
        {
            return View("~/Views/Estudiante/Matemáticas/Suma.cshtml");
        }

        public IActionResult Resta()
        {
            return View("~/Views/Estudiante/Matemáticas/Resta.cshtml");
        }

        public IActionResult Multiplicacion()
        {
            return View("~/Views/Estudiante/Matemáticas/Multiplicacion.cshtml");
        }


        public IActionResult Tutorias()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Material/getall");
            response.EnsureSuccessStatusCode();
            //List<Models.DistritoViewModel> categories = new List<Models.DistritoViewModel>();
            var content = response.Content.ReadAsStringAsync().Result;
            List<Models.MaterialViewModel> materiales = JsonConvert.DeserializeObject<List<Models.MaterialViewModel>>(content);

            foreach (var item in materiales)
            {
                response = serviceObj.GetResponse("api/Tutoria/?id=" + item.IdTutoriaCursos.ToString());
                response.EnsureSuccessStatusCode();
                item.Tutoria = response.Content.ReadAsAsync<Models.TutoriaViewModel>().Result;

                response = serviceObj.GetResponse("api/Curso/?id=" + item.Tutoria.IdCurso);
                response.EnsureSuccessStatusCode();
                item.Tutoria.Curso = response.Content.ReadAsAsync<Models.CursoViewModel>().Result;
            }

            return View(materiales);
        }

        [HttpPost]
        public IActionResult Calificar(IFormCollection value)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Tutoria/?id=" + value["idTutoria"].ToString());
            response.EnsureSuccessStatusCode();
            Models.TutoriaViewModel tutoria = response.Content.ReadAsAsync<Models.TutoriaViewModel>().Result;

            return View(tutoria);
        }

        [HttpPost]
        public IActionResult guardarCalificacion(IFormCollection value)
        {
            Models.CalificacionTutoriaViewModel calificacion = new Models.CalificacionTutoriaViewModel() { 
                IdTutoriaCursos = int.Parse(value["idTutoria"]),
                Calificacion = int.Parse(value["calificacion"])
            };

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Calificacion/agregar", calificacion);
            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index");
        }
    }
}
