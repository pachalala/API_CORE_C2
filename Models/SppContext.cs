using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RES_API.Models;

public partial class SppContext : DbContext
{
    public SppContext()
    {
    }

    public SppContext(DbContextOptions<SppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<UsuUsuario> UsuUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=10.201.20.103;database=SPP_TEST;uid=spp;pwd=spp2014; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.CodRegion);

            entity.ToTable("REGION");

            entity.Property(e => e.CodRegion)
                .ValueGeneratedNever()
                .HasColumnName("COD_REGION");
            entity.Property(e => e.ComprobantePos)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("COMPROBANTE_POS");
            entity.Property(e => e.Fonos)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("FONOS");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<UsuUsuario>(entity =>
        {
            entity.HasKey(e => e.UsuLogin);

            entity.ToTable("USU_USUARIOS");

            entity.HasIndex(e => e.UsuRut, "IX_USU_RUTS").IsUnique();

            entity.Property(e => e.UsuLogin)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("USU_LOGIN");
            entity.Property(e => e.UsuCambioclave)
                .HasColumnType("datetime")
                .HasColumnName("USU_CAMBIOCLAVE");
            entity.Property(e => e.UsuEnable)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USU_ENABLE");
            entity.Property(e => e.UsuIdrol).HasColumnName("USU_IDROL");
            entity.Property(e => e.UsuNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USU_NOMBRE");
            entity.Property(e => e.UsuNuevo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("USU_NUEVO");
            entity.Property(e => e.UsuPasswd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("USU_PASSWD");
            entity.Property(e => e.UsuRegion).HasColumnName("USU_REGION");
            entity.Property(e => e.UsuRut)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("USU_RUT");
            entity.Property(e => e.UsuUltimoacceso)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USU_ULTIMOACCESO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
