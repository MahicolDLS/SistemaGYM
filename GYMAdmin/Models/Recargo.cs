using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GYMAdmin.Models
{
    [Table(name:"Recargos")]
    public class Recargo
    {

        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)][Display(Name ="Codigo Recargo")][Column(name:"CodigoRecargo")]
        public int Codigo_Recargo { get; set; }

        [Required(ErrorMessage = "* Debe ingresar un Nombre {0,1}")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "* Debe ingresar una descripcion {0,1}")]
        [StringLength(150, MinimumLength = 3)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "* Debe ingresar un porcentaje valido para el recargo {0,1}")][Range(0,100)]
        public int Porcentaje { get; set; }
    



    }
}