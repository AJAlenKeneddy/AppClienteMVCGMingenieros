using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppClienteMVCGMingenieros.Models;

public partial class DatadecomprasgmContext : DbContext
{
    public DatadecomprasgmContext()
    {
    }

    public DatadecomprasgmContext(DbContextOptions<DatadecomprasgmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comprobante> Comprobantes { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Ubigeo> Ubigeos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comprobante>(entity =>
        {
            entity.HasKey(e => e.Idcomprobante).HasName("PK_FACTURAS");

            entity.ToTable("COMPROBANTES");

            entity.Property(e => e.Idcomprobante).HasColumnName("IDCOMPROBANTE");
            entity.Property(e => e.Concepto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CONCEPTO");
            entity.Property(e => e.Emitidorecibido)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("EMITIDORECIBIDO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.Importe)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("IMPORTE");
            entity.Property(e => e.Moneda)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MONEDA");
            entity.Property(e => e.Numerodocumento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NUMERODOCUMENTO");
            entity.Property(e => e.Razonsocial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RAZONSOCIAL");
            entity.Property(e => e.Ruc)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("RUC");
            entity.Property(e => e.Tipodocumento)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("TIPODOCUMENTO");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Departamento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Distrito)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Provincia)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ruc)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RUC");
            entity.Property(e => e.Ubigeo)
                .HasMaxLength(6)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ubigeo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ubigeo__3213E83F09BF8C59");

            entity.ToTable("ubigeo");

            entity.Property(e => e.Id)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.DepartmentId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("department_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.ProvinceId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("province_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
