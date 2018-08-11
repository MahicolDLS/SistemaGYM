using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GYMAdmin.Models
{
    [Table("Membrecias")]
    public class Membrecia
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "* Debe de ingresar un Nombre {0,1}")]
        [StringLength(80, MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "* Debe de ingresar el COSTO de la membresia {0,1}")]
        public int Costo { get; set; }

    }
}