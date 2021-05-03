using API_RestFull_Libros.Context;
using API_RestFull_Libros.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_RestFull_Libros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly AppDBContext context;

        public AutorController(AppDBContext context)
        {
            this.context = context;
        }

        // GET: api/<AutorController>
        [HttpGet]
        public IEnumerable<Autor> Get()
        {
            return context.Autor.ToList();
        }

        
        // POST api/<AutorController>
        [HttpPost]
        public ActionResult Post([FromBody] Autor autor)
        {
            try
            {
                context.Autor.Add(autor);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
