using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GYMAdmin.Models
{
    [Table(name:"Usuarios")]
    public class Usuario
    {
        [Key][Display(Name ="Codigo Usuario")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name:"CodigoUsuario")]
        public virtual int Codigo_Usuario { get; set; }

        [Required(ErrorMessage ="* Debe Ingresar el Nombre campo obligatorio")]
        [Display(Name ="Nombre Usuario")]
        [StringLength(25,MinimumLength =3)]
        [Column(name:"NombreUsuario")]
        public string Nombre_Usuario { get; set; }

        [Required(ErrorMessage = "* Debe Ingresar el Nombre campo obligatorio")]
        [StringLength(25, MinimumLength = 3)]
        public string Apellido { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "* Debe Ingresar un Email campo obligatorio")]
        [Display(Name ="Correo Electronico")]
        [Column(name:"CorreoElectronico")]
        public string  Correo_Electronico { get; set; }

        [Display(Name ="Tipo de Usuario")]
        [Required(ErrorMessage = "* Debe Seleccionar el tipo de Usuario")]
        [Column(name:"TipoUsuario")]
        public TipoUsuario Tipo_Usuario { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "* Debe ingresar una contraseña")]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name ="Contraseña")]
        [Column(name:"Contrasenia")]
        public string Pass { get; set; }

    }
}