using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_RestFull_Libros.Entities
{
    public class Autor
    {
        [Key]
        public string Nombre_Autor { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Ciudad_Procedencia { get; set; }
        public string Correo_Electronico_Autor { get; set; }
        //public List<Libro> Libro { get; set; }
    }
}
