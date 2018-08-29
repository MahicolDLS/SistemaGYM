using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GYMAdmin.Models
{
    [Table(name:"Articulos")]
    public class Articulo
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)][Column(name:"CodigoArticulo")][Display(Name ="Codigo Articulo")]
        public virtual int Codigo_Articulo { get; set; }

        [Required(ErrorMessage ="* Debe ingresar un Nombre")][StringLength(50,MinimumLength =3)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "* Debe ingresar un Nombre")]
        [StringLength(50, MinimumLength = 3)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "* Debe ingresar un Nombre")][Column(name:"PrecioCosto")][Display(Name ="Precio Costo")]
        public int Precio_Costo { get; set; }

        [Required(ErrorMessage = "* Debe ingresar un Nombre")]
        [Column(name: "PrecioVenta")]
        [Display(Name = "Precio Venta")]
        public int Precio_Venta { get; set; }

        [ForeignKey("Proveedor")][Display(Name ="Codigo Proveedor")]
        public virtual int Codigo_Proveedor { get; set; }

        public virtual Proveedor  Proveedor{ get; set; }

    }
}