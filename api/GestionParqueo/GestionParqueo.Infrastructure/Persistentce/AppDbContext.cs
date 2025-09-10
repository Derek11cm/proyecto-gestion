using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionParqueo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using GestionParqueo.Application.Interfaces;

namespace GestionParqueo.Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IApplicationDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Parqueo> Parqueos { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<AsignacionParqueo> AsignacionesParqueo { get; set; }
        public DbSet<ReservacionHabitacion> ReservacionesHabitacion { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<FacturaDetalle> FacturaDetalles { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<OrdenServicio> OrdenesServicio { get; set; }
        public DbSet<OrdenServicioDetalle> OrdenesServicioDetalle { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        // Si necesitas configurar relaciones complejas o datos iniciales (seeds),
        // puedes hacerlo sobreescribiendo el método OnModelCreating aquí.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdenServicio>()
             .HasOne(o => o.Vehiculo)
             .WithMany(v => v.OrdenesServicio)
             .HasForeignKey(o => o.VehiculoId)
             .OnDelete(DeleteBehavior.Restrict); // evita cascada

            modelBuilder.Entity<OrdenServicio>()
                .HasOne(o => o.Cliente)
                .WithMany(c => c.OrdenesServicio)
                .HasForeignKey(o => o.ClienteId)
                .OnDelete(DeleteBehavior.Cascade); // esta puede quedarse en cascada

        }

    }
        
}