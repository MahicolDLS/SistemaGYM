using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GYMAdmin.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("BD-SistemaGYM", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<GYMAdmin.Models.Membrecia> Membrecias { get; set; }

        public System.Data.Entity.DbSet<GYMAdmin.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<GYMAdmin.Models.FichaCliente> FichaClientes { get; set; }

        public System.Data.Entity.DbSet<GYMAdmin.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<GYMAdmin.Models.Maquina> Maquinas { get; set; }

        public System.Data.Entity.DbSet<GYMAdmin.Models.Mantenimiento> Mantenimientoes { get; set; }

        public System.Data.Entity.DbSet<GYMAdmin.Models.Recargo> Recargoes { get; set; }
    }
}