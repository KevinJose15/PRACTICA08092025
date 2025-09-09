using Microsoft.EntityFrameworkCore;
using PRACTICA08092025.Entidades;

namespace AuthApi.Repositorios
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        // 👇 Corrección: ahora es un DbSet de CategoriaKM
        public DbSet<CategoriaKM> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Email único
            modelBuilder.Entity<Usuarios>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Relación 1 Rol -> N Usuarios
            modelBuilder.Entity<Usuarios>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId);

            // Mapear CategoriaKM a la tabla en la BD
            modelBuilder.Entity<CategoriaKM>().ToTable("CategoriaKM");
        }
    }
}
