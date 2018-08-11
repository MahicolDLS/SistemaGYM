using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GYMAdmin.Models
{
    [Table("FichaClientes")]
    public class FichaCliente
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        [Display(Name = "Fecha de Pago")]
        [Required(ErrorMessage = "* Debe ingresar el Nombre {0,1}")]
        [Column(name: "FechaPago")]
        public DateTime Fecha_Pago { get; set; }

        [Required(ErrorMessage = "* Debe ingresar el Apellido {0,1}")]
        [Display(Name = "Vencimiento de Pago")]
        [Column(name: "VencimientoPago")]
        public string Vencimiento_Pago { get; set; }

        [Required(ErrorMessage = "* Debe ingresar una Direccion {0,1}")]
        [Display(Name = "Fecha de Ingreso")]
        [Column(name: "FechaIngreso")]
        public DateTime Fecha_Ingreso { get; set; }

        [Required(ErrorMessage = "* Debe ingresar un Telefono {0,1}")]
        [StringLength(150, MinimumLength = 3)]
        public string Enfermedades { get; set; }

        [Required(ErrorMessage = "* Debe ingresar una Asistencia {0,1}")]
        [StringLength(80, MinimumLength = 3)]
        [Column(name: "AsistenciaMedica")]
        [Display (Name ="Tipo de Asistencia")]
        public string Tipo_Asistencia_Medica { get; set; }

        [Display(Name = "Cliente")]
        [ForeignKey("Cliente")]
        [Column(name: "CodigoCliente")]
        public virtual int Codigo_Cliente { get; set; }

        public virtual Cliente Cliente { get; set; }

        [ForeignKey("Membrecia")]
        [Display(Name = "Membrecia")]
        [Column(name: "CodigoMembrecia")]
        public virtual int Codigo_Membrecia { get; set; }


        public virtual Membrecia Membrecia { get; set; }
    }
}
