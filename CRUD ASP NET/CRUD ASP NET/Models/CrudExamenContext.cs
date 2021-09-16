using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
            string connectionStringLaptop = "Server=DESKTOP-4CF079O\\SQLEXPRESS;Database=CrudExamen;Trusted_Connection=True;";
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(connectionStringLaptop);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<PersonasSql>(entity =>
            {
                entity.HasNoKey();

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
