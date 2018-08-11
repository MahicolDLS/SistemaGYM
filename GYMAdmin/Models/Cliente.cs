using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GYMAdmin.Models
{
    [Table("Clientes")]
    public class Cliente
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "* Debe ingresar el Nombre {0,1}")]
        [Display(Name = "Nombre Cliente")]
        public string Nombre_Cliente { get; set; }
        [Required(ErrorMessage = "* Debe ingresar el Apellido {0,1}")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "* Debe ingresar una Direccion {0,1}")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "* Debe ingresar un Telefono {0,1}")]
        [StringLength(20,MinimumLength = 3)]
        public string Telefono { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "* Debe ingresar un correo valido {0,1}")]
        public string Correo { get; set; }




    }
}