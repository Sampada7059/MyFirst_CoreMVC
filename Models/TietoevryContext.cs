using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyFirst_CoreMVC.Models
{
    public partial class TietoevryContext : DbContext
    {
        public TietoevryContext()
        {
        }

        public TietoevryContext(DbContextOptions<TietoevryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Trainee> Trainees { get; set; } = null!;

       // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       // {
          //  if (!optionsBuilder.IsConfigured)
          //  {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
               // optionsBuilder.UseSqlServer("Server=ELW5113\\SQLEXPRESS;Database=Tietoevry;Trusted_Connection=True; ");
          //  }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trainee>(entity =>
            {
                entity.HasKey(e => e.Tid)
                    .HasName("PK__Trainee__C456D7298E465151");

                entity.ToTable("Trainee");

                entity.Property(e => e.Tid)
                    .ValueGeneratedNever()
                    .HasColumnName("TID");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
