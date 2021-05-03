using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_RestFull_Libros.Entities
{
    public class Editorial
    {
        [Key]
        public string Nombre_Editorial { get; set; }
        public string Direccion_Correspondencia { get; set; }
        public Int64 Telefono { get; set; }
        public string Correo_Electronico_Editorial { get; set; }
        public int Maximo_Libros_Registrados { get; set; }
        //public List<Libro> Libro { get; set; }
    }
}
