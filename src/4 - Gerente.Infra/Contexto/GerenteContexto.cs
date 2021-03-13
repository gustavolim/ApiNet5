using Gerente.Dominio.Entidades;
using Gerente.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Gerente.Infra.Contexto
{
    public class GerenteContexto : DbContext
    {
        public GerenteContexto()
        {       
        }

        public GerenteContexto(DbContextOptions<GerenteContexto> options) : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsuarioMap());
        }
    }
}