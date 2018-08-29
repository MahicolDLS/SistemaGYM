using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GYMAdmin.Models
{
    [Table(name:"FichaClientes")]
    public class FichaCliente
    {
       [Key][Column(name:"Cod.FichaCliente")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        [Display(Name = "Fecha Pago")]
        [Required(ErrorMessage =" * Debe ingresar Fecha de Pago")]
        [Column(name: "FechaPago")]
        public DateTime Fecha_Pago { get; set; }

        [Display(Name = "Vencimiento Pago")]
        [Required(ErrorMessage = " * Debe ingresar Fecha de Vencimiento")][Column(name:"VencimientoPago")]
        public DateTime Vencimiento_Pago { get; set; }

        [Display(Name = "Fecha Ingreso")]
        [Required(ErrorMessage = " * Debe ingresar la Fecha de Ingreso")]
        [Column(name: "FechaIngreso")]
        public DateTime Fecha_Ingreso { get; set; }

        [ForeignKey("Cliente")][Column(name:"Cod.Cliente")][Display(Name ="Cod. Cliente")]
        public int Codigo_Cliente { get; set; }

        public virtual Cliente Cliente { get; set; }


        public string Enfermedades { get; set; }

        [Display(Name = "Tipo Asistencia")]
        [Column(name: "TipoAsistencia")]
        [Required(ErrorMessage = " * Debe ingresar tipo de Asistencia ")]
        public string Tipo_Asistencia { get; set; }

        public string Objetivos { get; set; }

        [Display(Name = "Cod. Alimentacion")][ForeignKey("Alimentacion")]
        [Column(name: "Cod.Alimentacion")]
        [Required(ErrorMessage = " * Debe seleccionar alimentacion ")]
        public int Codigo_Alimentacion { get; set; }

        public virtual Alimentacion Alimentacion { get; set; }


        [Display(Name = "Cod. Membrecia")]
        [Column(name: "Cod.Membrecia")]
        [ForeignKey("Membrecia")]
        [Required(ErrorMessage = " * Debe seleccionar una Memebrecia ")]
        public int Codigo_Membrecia { get; set; }

        public virtual Membrecia Membrecia { get; set; }
    }
}