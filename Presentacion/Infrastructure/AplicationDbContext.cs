using Models;
using Models.Módulo_Barbero;
using Models.Módulo_Cliente;
using Microsoft.EntityFrameworkCore;
using Models.Módulo_Citas;
using Models.Módulo_Inventario;
using Models.Módulo_Ventas;
using Models.Módulo_Carrito;

namespace Presentacion.Infrastructure
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Barbero> Barberos { get; set; }

        public DbSet<Especialidad> Especialidades { get; set; }

        public DbSet<Jornada> Jornadas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Carrito> CarritoCliente { get; set; }

        public DbSet<Citas> CitasCliente { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Ventas> Ventas { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().Property(a => a.Estado).HasDefaultValue(true);
            modelBuilder.Entity<Usuario>().Property(a => a.FechaReg).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Barbero>().Property(h => h.Estado).HasDefaultValue(true);
            modelBuilder.Entity<Barbero>().Property(h => h.FechaReg).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Especialidad>().Property(a => a.Estado).HasDefaultValue(true);
            modelBuilder.Entity<Especialidad>().Property(a => a.FechaReg).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Jornada>().Property(a => a.Estado).HasDefaultValue(true);
            modelBuilder.Entity<Jornada>().Property(a => a.FechaReg).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Cliente>().Property(a => a.Estado).HasDefaultValue(true);
            modelBuilder.Entity<Cliente>().Property(a => a.FechaReg).HasDefaultValueSql("GETDATE()");
        }

    }
}
