using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using ServiciosDominio.Web;
using System.Net.Http;

namespace Cliente.Web.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        [HttpGet]
        public ActionResult Index()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44300/");
            var request = httpClient.GetAsync("api/libro").Result;

            if (request.IsSuccessStatusCode)
            {
                var respuestaString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Libro>>(respuestaString);

                return View(listado);
            }
            return View(new List<Libro>());
        }

        [HttpGet]
        public ActionResult CreateLibro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateLibro(Libro libro)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44300/");
            var request = httpClient.PostAsync("api/libro", libro, new JsonMediaTypeFormatter()).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var resultadoBool = JsonConvert.DeserializeObject<bool>(resultString);
                if (resultadoBool)
                {
                    return RedirectToAction("Index");
                }
                return View(libro);
            }
            return View(libro);

        }



        [HttpGet]
        public ActionResult UpdateLibro(int id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44300/");
            var request = httpClient.GetAsync("api/libro?id=" + id).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var informacion = JsonConvert.DeserializeObject<Libro>(resultString);

                return View(informacion);
            }
            return View();
        }

        [HttpPost]
        public ActionResult UpdateLibro(Libro libro)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44300/");
            var request = httpClient.PutAsync("api/libro", libro, new JsonMediaTypeFormatter()).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var resultadoBool = JsonConvert.DeserializeObject<bool>(resultString);
                if (resultadoBool)
                {
                    return RedirectToAction("Index");
                }
                return View(libro);
            }
            return View(libro);

        }



        [HttpGet]
        public ActionResult DeleteLibro(int id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44300/");
            var request = httpClient.DeleteAsync("api/libro?id=" + id).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var resultadoBool = JsonConvert.DeserializeObject<bool>(resultString);
                if (resultadoBool)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult DetalleLibro(int id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44300/");
            var request = httpClient.GetAsync("api/libro?id=" + id).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var informacion = JsonConvert.DeserializeObject<Libro>(resultString);

                return View(informacion);
            }
            return View();
        }
    }

}