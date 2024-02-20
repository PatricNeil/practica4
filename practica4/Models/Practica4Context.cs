using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace practica4.Models;

public partial class Practica4Context : DbContext
{
    public Practica4Context()
    {
    }

    public Practica4Context(DbContextOptions<Practica4Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Direccione> Direcciones { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("server=LAPTOP-2J3H8ERB; database=practica4; integrated security=true; Encrypt=False; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PK__Cargos__8D69B95F30E2A7E0");

            entity.Property(e => e.IdCargo).HasColumnName("ID_Cargo");
            entity.Property(e => e.NombreCargo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_Cargo");
            entity.Property(e => e.Salario).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Direccione>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__Direccio__F4CC417286BFCBCA");

            entity.Property(e => e.IdDireccion).HasColumnName("ID_Direccion");
            entity.Property(e => e.Calle)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__B7872C90970577CC");

            entity.HasIndex(e => e.Ci, "UQ__Empleado__32149A7A1EF91529").IsUnique();

            entity.Property(e => e.IdEmpleado).HasColumnName("ID_Empleado");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Apellido_Materno");
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Apellido_Paterno");
            entity.Property(e => e.Ci)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CI");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Correo_Electronico");
            entity.Property(e => e.IdCargo).HasColumnName("ID_Cargo");
            entity.Property(e => e.IdDireccion).HasColumnName("ID_Direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono).HasColumnType("numeric(8, 0)");

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdCargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleados__ID_Ca__4F7CD00D");

            entity.HasOne(d => d.IdDireccionNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdDireccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleados__ID_Di__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
