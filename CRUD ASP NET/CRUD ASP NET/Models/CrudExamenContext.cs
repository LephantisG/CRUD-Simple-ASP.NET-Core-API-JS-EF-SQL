using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace CRUD_ASP_NET.Models
{
    public partial class CrudExamenContext : DbContext
    {
        public CrudExamenContext()
        {
        }

        public CrudExamenContext(DbContextOptions<CrudExamenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PersonasSql> PersonasSqls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionStringCasa = "Server=LEPHANTIS\\SERVERGABRIEL;Database=CrudExamen;Trusted_Connection=True;";
            //string connectionStringLaptop = @"Server=DESKTOP-4CF079O\SQLEXPRESS;Database=CrudExamen;Trusted_Connection=True;";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionStringCasa);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<PersonasSql>(entity =>
            {
                //It does have a key lol
                //entity.HasNoKey();

                entity.ToTable("PersonasSQL");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Puntos).HasColumnName("puntos");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
