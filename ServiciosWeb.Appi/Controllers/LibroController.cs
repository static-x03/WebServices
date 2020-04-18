using BaseDeDatos.Servicios.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;


namespace ServiciosWeb.Appi.Controllers
{
    public class LibroController : ApiController
    {
        LibrosConectionsBD BD = new LibrosConectionsBD();

        [HttpGet]
        public IEnumerable<Libro> GetLibros()
        {
            var listado = BD.Libro.ToList();
            return listado;
        }

        [HttpGet]
        public Libro GetLibro(int id)
        {
            var LibroId = BD.Libro.FirstOrDefault(x => x.IdLibro == id);
            return LibroId;
        }

        [HttpPost]
        public bool CreateLibro(Libro libro)
        {
            BD.Libro.Add(libro);
            return BD.SaveChanges() > 0;
        }

        [HttpPut]
        public bool Updatelibro(Libro libro)
        {
            var libroActualizar = BD.Libro.FirstOrDefault(x => x.IdLibro == libro.IdLibro);
            libroActualizar.Titulo = libro.Titulo;
            libroActualizar.Autor = libro.Autor;
            libroActualizar.Sinopsis = libro.Sinopsis;
            libroActualizar.Editorial = libro.Editorial;
            libroActualizar.Formato = libro.Formato;
            libroActualizar.Genero = libro.Genero;
            libroActualizar.Idioma = libro.Idioma;
            libroActualizar.Disponible = libro.Disponible;

            return BD.SaveChanges() > 0;
        }

        [HttpDelete]
        public bool DeleteLibro(int id)
        {
            var EliminarLibro = BD.Libro.FirstOrDefault(x => x.IdLibro == id);
            BD.Libro.Remove(EliminarLibro);
            return BD.SaveChanges() > 0;
        }
    }
}
