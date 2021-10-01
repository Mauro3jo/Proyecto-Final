using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Models
{
    public class TurnosContext : DbContext
    {
       public TurnosContext(DbContextOptions<TurnosContext> opciones)
       : base(opciones)
       {

       }
       
     
        public DbSet<Paciente> Paciente{get;set;}
        public DbSet<Login> Login { get; set; }
        public DbSet<Practica> Practica { get; set; }
        public DbSet<Orden> Orden { get; set; }
        public DbSet<OrdenDeTrabajo> OrdenDeTrabajo { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           
             modelBuilder.Entity<Paciente>(entidad =>
        {
            entidad.ToTable("Paciente");

            entidad.HasKey(p => p.IdPaciente);

            entidad.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);

            entidad.Property(p => p.Apellido)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);

            entidad.Property(p => p.DNI)
            .IsRequired()
            .HasMaxLength(8)
            .IsUnicode(true);

            entidad.Property(p => p.FechaNac)
            .IsRequired()
            .IsUnicode(false);

            entidad.Property(p => p.Direccion)
            .IsRequired()
            .HasMaxLength(250)
            .IsUnicode(false);

            entidad.Property(p => p.Telefono)
            .IsRequired()
            .HasMaxLength(20)
            .IsUnicode(false);

        }
        );
      

      modelBuilder.Entity<Login>(entidad =>{
           entidad.ToTable("Login");

           entidad.HasKey(l => l.LoginId);
           
           entidad.Property(l => l.Usuario)
           .IsRequired();

           entidad.Property(l => l.Password)
           .IsRequired();
      });

            modelBuilder.Entity<Practica>(entidad=>
            {
                 entidad.ToTable("Practica");
                 entidad.HasKey(p =>p.IdPractica);

                 entidad.Property(p => p.Codigo)
                 .IsRequired()
                 .HasMaxLength(8)
                 .IsUnicode(true);

                 entidad.Property(p => p.NombrePractica)
                 .IsRequired()
                 .HasMaxLength(200)
                 .IsUnicode(false);

            }
            );
            modelBuilder.Entity<Orden>(entidad =>{
              
              entidad.ToTable("Orden");

              entidad.HasKey(o=>o.IdOrden);


              entidad.Property(o => o.NumeroOrden)
                 .IsRequired()
                 .HasMaxLength(200)
                 .IsUnicode(false);

            entidad.Property(o => o.FechaIngreso)
            .IsRequired()
            .IsUnicode(false);


              entidad.Property(o => o.IdPaciente)
            .IsRequired()
            .IsUnicode(false);

             entidad.Property(o => o.IdPractica)
            .IsRequired()
            .IsUnicode(false);
            });

         modelBuilder.Entity<Orden>().HasOne(x=>x.Practica)
       .WithMany(P=> P.Orden)
       .HasForeignKey(p => p.IdPractica);

        modelBuilder.Entity<Orden>().HasOne(x=>x.Paciente)
       .WithMany(P=> P.Orden)
       .HasForeignKey(p => p.IdPaciente);

        modelBuilder.Entity<OrdenDeTrabajo>(entidad =>{
              
              entidad.ToTable("OrdenDeTrabajo");

              entidad.HasKey(o=>o.IdOrdenDeTrabajo);

              entidad.Property(o => o.ValoresDePractica)
                 .IsRequired()
                 .HasMaxLength(200)
                 .IsUnicode(false);

            entidad.Property(o => o.IdOrden)
            .IsRequired()
            .IsUnicode(false);

          
            });

         modelBuilder.Entity<OrdenDeTrabajo>().HasOne(x=>x.Orden)
       .WithMany(P=> P.OrdenDeTrabajo)
       .HasForeignKey(p => p.IdOrden);

        modelBuilder.Entity<AnalisisFinal>(entidad =>{
              
              entidad.ToTable("AnalisisFinal");

              entidad.HasKey(o=>o.IdAnalisisFinal);

              entidad.Property(o => o.FechaEmision)
            .IsRequired()
            .IsUnicode(false);

            entidad.Property(o => o.IdOrdenDeTrabajo)
            .IsRequired()
            .IsUnicode(false);

          
            });

             modelBuilder.Entity<AnalisisFinal>().HasOne(x=>x.OrdenDeTrabajo)
       .WithMany(P=> P.AnalisisFinal)
       .HasForeignKey(p => p.IdOrdenDeTrabajo);

      

       }

       public DbSet<Turnos.Models.AnalisisFinal> AnalisisFinal { get; set; }
       
       
       
        
    }
}