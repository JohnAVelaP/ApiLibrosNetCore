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
    public class EditorialController : ControllerBase
    {
        private readonly AppDBContext context;

        public EditorialController(AppDBContext context)
        {
            this.context = context;
        }

        // GET: api/<EditorialController>
        [HttpGet]
        public IEnumerable<Editorial> Get()
        {
            return context.Editorial.ToList();
        }

        // POST api/<EditorialController>
        [HttpPost]
        public ActionResult Post([FromBody] Editorial editorial)
        {
            try
            {
                if (editorial.Maximo_Libros_Registrados > 0)
                { 
                    context.Editorial.Add(editorial);
                    context.SaveChanges();
                }
                else
                {
                    editorial.Maximo_Libros_Registrados = -1;
                    context.Editorial.Add(editorial);
                    context.SaveChanges();
                }
                
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }            
        }
    }
}
