using Microsoft.EntityFrameworkCore;
using TaskManager.API.Modelos;

namespace TaskManager.API.Datos
{
    public class ContextoBaseDatos : DbContext
    {

        public ContextoBaseDatos(DbContextOptions<ContextoBaseDatos> options)
            : base(options)
        {

        }


        public DbSet<Tarea> Tareas { get; set; }

        public DbSet<LogTarea> LogTareas { get; set; }

        public DbSet<CatEstado> Estados { get; set; }

        public DbSet<CatPrioridad> Prioridades { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CatEstado>()
                .ToTable("CatEstados");


            modelBuilder.Entity<CatPrioridad>()
                .ToTable("CatPrioridades");


            modelBuilder.Entity<LogTarea>()
                .ToTable("LogTareas");


            modelBuilder.Entity<Tarea>()
                .ToTable("Tareas");


            modelBuilder.Entity<CatEstado>()
                .HasKey(x => x.EstadoId);


            modelBuilder.Entity<CatPrioridad>()
                .HasKey(x => x.PrioridadId);


            modelBuilder.Entity<LogTarea>()
                .HasKey(x => x.LogId);



            base.OnModelCreating(modelBuilder);
        }
    }
}