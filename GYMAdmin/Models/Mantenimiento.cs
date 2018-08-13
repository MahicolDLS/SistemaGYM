using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GYMAdmin.Models
{
    [Table(name:"Mantenimientos")]
    public class Mantenimiento
    {
        [Key][Column(name:"CodigoMantenimiento")][Display(Name ="Codigo Mantenimiento")] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Codigo_Mantenimiento { get; set; }

        public virtual Maquina Maquina { get; set; }

        [Column(name: "CodigoMaquina")] [Display(Name = "Codigo Maquina")] [ForeignKey("Maquina")]
        public int Codigo_Maquina { get; set; }

        [Required(ErrorMessage ="* Ingrese una Descripcion")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "* Ingrese un Importe")]
        public int Costo { get; set; }


        [Required(ErrorMessage = "* Ingrese una fecha Valida")][Column(name: "FechaMantenimiento")][Display(Name ="Fecha de Mantenimiento")]
        public DateTime Fecha_Mantenimiento { get; set; }

        [Display(Name = "Codigo de Usuario")][ForeignKey("Usuario")][Column(name:"CodigoUsuario")]
        public virtual int Codigo_Usuario  { get; set; }

        public virtual Usuario Usuario { get; set; }

    }
}