using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GYMAdmin.Models
{
    [Table(name:"Alimentaciones")]
    public class Alimentacion
    {
        [Key][Column(name:"CodigoAlimentacion")][DatabaseGenerated(DatabaseGeneratedOption.Identity)][Display(Name ="CodgioAlimentacion")]
        public int Codigo_Alimentacion { get; set; }

        [Required (ErrorMessage ="* Debe de ingresar un Nombre")]
        [StringLength(30,MinimumLength =3)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "* Debe de ingresar una Descripcion")]
        [StringLength(300, MinimumLength = 3)]
        public string Descripcion { get; set; }
    }
}