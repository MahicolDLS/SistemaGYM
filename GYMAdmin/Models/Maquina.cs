using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GYMAdmin.Models
{   [Table(name:"Maquinas")]
    public class Maquina
    {
        [Key][Display(Name ="Codigo Maquina")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name:"CodigoMaquina")]
        public int Codigo_Maquina { get; set; }

        [Display(Name ="Nombre Maquina")]
        [Column(name:"NombreMaquina")]
        [Required(ErrorMessage = "* Ingrese el Nombre de la Maquina")]
        public string Nombre_Maquina { get; set; }

        [Required(ErrorMessage ="* Ingrese la cantidad")]
        public int Cantidad { get; set; }
    }
}