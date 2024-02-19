using Microsoft.EntityFrameworkCore;
using MvcNetCoreEF.Models;

namespace MvcNetCoreEF.Data
{
    public class HospitalContext : DbContext
    {
        // Tendremos un constructor que recibirá las opciones
        // de inicio y conexión de la base de datos
        // Dichas opciones deben ser enviadas a la clase base
        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options)
        { }

        // Por cada Model necesitamos una colección DbSet que será la
        // que utilizaremos para las consultas LINQ
        public DbSet<Hospital> Hospitales { get; set; }

        public DbSet<Empleado> Empleados { get; set; }
    }
}
