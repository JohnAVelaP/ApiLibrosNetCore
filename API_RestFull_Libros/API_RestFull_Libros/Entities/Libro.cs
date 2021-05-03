using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_RestFull_Libros.Entities
{
    public class Libro
    {
        [Key]
        public int Cod_Libro { get; set; }
        public string Titulo_Libro { get; set; }
        public int Año { get; set; }
        public string Genero { get; set; }
        public int Numero_de_Paginas { get; set; }

        [ForeignKey("Editorial")]
        public string Nombre_Editorial { get; set; }
        public Editorial Editorial { get; set; }

        [ForeignKey("Autor")]
        public string Nombre_Autor { get; set; }
        public Autor Autor { get; set; }

    }
}
