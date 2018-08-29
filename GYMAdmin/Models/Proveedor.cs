using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GYMAdmin.Models
{
    [Table(name:"Proveedores")]
    public class Proveedor
    {
        [Key][Column(name:"Codigo Proveedor")][Display(Name ="Codgio Proveedor")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Codigo_Proveedor { get; set; }

        [Required(ErrorMessage ="* Debe ingresar un Nombre ")][Display(Name ="Nombre Empresa")][Column(name:"NombreEmpresa")]
        [StringLength(60, MinimumLength = 3)]
        public string Nombre_Empresa { get; set; }

        public string Rut { get; set; }

        [Required(ErrorMessage = "* Debe ingresar un Nombre del Proveedor ")]
        [StringLength(60, MinimumLength = 3)][Display(Name = "Nombre Proveedor")]
        [Column(name: "NombreProveedor")]
        public string Nombre_Proveedor { get; set; }

        [Required(ErrorMessage = "* Debe ingresar una Direccion ")][StringLength(60, MinimumLength =3)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "* Debe ingresar un Telefono de contacto ")][DataType(DataType.PhoneNumber)]
        [StringLength(60, MinimumLength = 3)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "* Debe ingresar un Correo ")][DataType(DataType.EmailAddress)]
        [StringLength(60, MinimumLength = 3)]
        public string Correo { get; set; }
    }
}