// En GestionParqueo.Application/Interfaces/IApplicationDbContext.cs
using GestionParqueo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestionParqueo.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Vehiculo> Vehiculos { get; set; }
        DbSet<Parqueo> Parqueos { get; set; }
        DbSet<Habitacion> Habitaciones { get; set; }
        DbSet<AsignacionParqueo> AsignacionesParqueo { get; set; }
        DbSet<ReservacionHabitacion> ReservacionesHabitacion { get; set; }
        DbSet<Factura> Facturas { get; set; }
        DbSet<FacturaDetalle> FacturaDetalles { get; set; }
        DbSet<Pago> Pagos { get; set; }
        DbSet<Servicio> Servicios { get; set; }
        DbSet<OrdenServicio> OrdenesServicio { get; set; }
        DbSet<OrdenServicioDetalle> OrdenesServicioDetalle { get; set; }
        DbSet<Usuario> Usuarios { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}