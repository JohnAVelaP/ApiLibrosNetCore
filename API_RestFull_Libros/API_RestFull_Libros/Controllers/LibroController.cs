using API_RestFull_Libros.Context;
using API_RestFull_Libros.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_RestFull_Libros.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        

        private readonly AppDBContext context;

        public LibroController(AppDBContext context)
        {
            this.context = context;
        }


        // GET: api/<LibroController>
        [HttpGet]
        [EnableCors("AnotherPolicy")]
        public ActionResult<IEnumerable<Libro>> Get()
        {
            return context.Libro.ToList();
        }

        // GET api/<ValuesController>/5
        [EnableCors("Policy1")]
        [HttpGet("{id}", Name = "LibroCreado")]
        public IActionResult GetById(int id)
        {
            var libro = context.Libro.FirstOrDefault(l => l.Cod_Libro == id);
            if (libro == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(libro);
            }

        }

        // GET api/<ValuesController>/5
        //[HttpGet("{edito}", Name = "LibrosxEditorial")]
        //public IActionResult GetByEditorial( string edito)
        //{

        //    var libro = context.Libro.Count(l => l.Nombre_Editorial == edito);

        //    if (libro == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(libro);
        //    }

        //}





        // POST api/<LibroController>
        [HttpPost]
        public ActionResult Post([FromBody] Libro libro)
        {
            string Error;
            try
            {
                var datoseditorial = context.Editorial.FirstOrDefault(l => l.Nombre_Editorial == libro.Nombre_Editorial);
                if (datoseditorial is null)
                {
                    Error = "La editorial no está registrada";
                    return BadRequest(Error);
                }
                var datosautor = context.Autor.FirstOrDefault(l => l.Nombre_Autor == libro.Nombre_Autor);
                if (datosautor is null)
                {
                    Error = "El autor no está registrado";
                    return BadRequest(Error);
                }
                var cuenta = context.Libro.Count(l => l.Nombre_Editorial == libro.Nombre_Editorial);
                if (cuenta >= datoseditorial.Maximo_Libros_Registrados)
                {
                    Error = "No es posible registrar el libro, se alcanzó el máximo permitido.";
                    return BadRequest(Error);                    
                }
                else
                {
                    context.Libro.Add(libro);
                    context.SaveChanges();
                    return Ok();
                }                
            }
            catch (Exception ex)
            {        
                return BadRequest();
            }
        }
    }
}
