using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OboardingAutomotriz.Entities.Models;

#nullable disable

namespace OboardingAutomotriz.Infraestructure.Context
{
    public partial class BBDDOnboardingContext : DbContext
    {
        public BBDDOnboardingContext()
        {
        }

        public BBDDOnboardingContext(DbContextOptions<BBDDOnboardingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AsignacionCliente> AsignacionClientes { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Ejecutivo> Ejecutivos { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Patio> Patios { get; set; }
        public virtual DbSet<SolicitudCredito> SolicitudCreditos { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<AsignacionCliente>(entity =>
            {
                entity.HasKey(e => e.AsId)
                    .HasName("PK_Asignacion_cliente");

                entity.ToTable("asignacion_cliente");

                entity.Property(e => e.AsId).HasColumnName("as_id");

                entity.Property(e => e.AsFechaAsignacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("as_fecha_asignacion");

                entity.Property(e => e.AsIdCliente).HasColumnName("as_id_cliente");

                entity.Property(e => e.AsIdPatio).HasColumnName("as_id_patio");

                entity.HasOne(d => d.AsIdClienteNavigation)
                    .WithMany(p => p.AsignacionClientes)
                    .HasForeignKey(d => d.AsIdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_asignacion_cliente_cliente");

                entity.HasOne(d => d.AsIdPatioNavigation)
                    .WithMany(p => p.AsignacionClientes)
                    .HasForeignKey(d => d.AsIdPatio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_asignacion_cliente_patio");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.ClIdCliente)
                    .HasName("PK_cl_cliente");

                entity.ToTable("cliente");

                entity.Property(e => e.ClIdCliente).HasColumnName("cl_id_cliente");

                entity.Property(e => e.ClApellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cl_apellidos");

                entity.Property(e => e.ClDireccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cl_direccion");

                entity.Property(e => e.ClEdad)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cl_edad");

                entity.Property(e => e.ClEstadoCivil)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cl_estado_civil");

                entity.Property(e => e.ClFechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("cl_fecha_nacimiento");

                entity.Property(e => e.ClIdentificacion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cl_identificacion");

                entity.Property(e => e.ClIdentificacionConyuge)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cl_identificacion_conyuge");

                entity.Property(e => e.ClNombreConyuge)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cl_nombre_conyuge");

                entity.Property(e => e.ClNombres)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cl_nombres");

                entity.Property(e => e.ClSujetoCredito).HasColumnName("cl_sujeto_credito");

                entity.Property(e => e.ClTelefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cl_telefono");
            });

            modelBuilder.Entity<Ejecutivo>(entity =>
            {
                entity.HasKey(e => e.EjId)
                    .HasName("PK_dt_ejecutivo");

                entity.ToTable("ejecutivo");

                entity.Property(e => e.EjId).HasColumnName("ej_id");

                entity.Property(e => e.EjApellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ej_apellido");

                entity.Property(e => e.EjCelular)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ej_celular");

                entity.Property(e => e.EjDireccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ej_direccion");

                entity.Property(e => e.EjEdad)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ej_edad");

                entity.Property(e => e.EjIdPatio).HasColumnName("ej_id_patio");

                entity.Property(e => e.EjIdentificacion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ej_identificacion");

                entity.Property(e => e.EjNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ej_nombre");

                entity.Property(e => e.EjTelefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ej_telefono");

                entity.HasOne(d => d.EjIdPatioNavigation)
                    .WithMany(p => p.Ejecutivos)
                    .HasForeignKey(d => d.EjIdPatio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ejecutivo_patio");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.MaIdMarca)
                    .HasName("PK_au_marca");

                entity.ToTable("marca");

                entity.Property(e => e.MaIdMarca).HasColumnName("ma_id_marca");

                entity.Property(e => e.MaMarcaAuto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ma_marca_auto");
            });

            modelBuilder.Entity<Patio>(entity =>
            {
                entity.HasKey(e => e.PaId);

                entity.ToTable("patio");

                entity.Property(e => e.PaId).HasColumnName("pa_id");

                entity.Property(e => e.PaDireccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pa_direccion");

                entity.Property(e => e.PaNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pa_nombre");

                entity.Property(e => e.PaTelefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("pa_telefono");
            });

            modelBuilder.Entity<SolicitudCredito>(entity =>
            {
                entity.HasKey(e => e.ScId);

                entity.ToTable("solicitud_credito");

                entity.Property(e => e.ScId).HasColumnName("sc_id");

                entity.Property(e => e.ScCuotas).HasColumnName("sc_cuotas");

                entity.Property(e => e.ScEntrada)
                    .HasColumnType("money")
                    .HasColumnName("sc_entrada");

                entity.Property(e => e.ScEstado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sc_estado");

                entity.Property(e => e.ScIdCliente).HasColumnName("sc_id_cliente");

                entity.Property(e => e.ScIdEjecutivo).HasColumnName("sc_id_ejecutivo");

                entity.Property(e => e.ScIdPatio).HasColumnName("sc_id_patio");

                entity.Property(e => e.ScIdVehiculo).HasColumnName("sc_id_vehiculo");

                entity.Property(e => e.ScMesesPlazo).HasColumnName("sc_meses_plazo");

                entity.Property(e => e.ScObservacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sc_observacion");

                entity.HasOne(d => d.ScIdClienteNavigation)
                    .WithMany(p => p.SolicitudCreditos)
                    .HasForeignKey(d => d.ScIdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_solicitud_credito_cliente");

                entity.HasOne(d => d.ScIdEjecutivoNavigation)
                    .WithMany(p => p.SolicitudCreditos)
                    .HasForeignKey(d => d.ScIdEjecutivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_solicitud_credito_ejecutivo");

                entity.HasOne(d => d.ScIdPatioNavigation)
                    .WithMany(p => p.SolicitudCreditos)
                    .HasForeignKey(d => d.ScIdPatio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_solicitud_credito_patio");

                entity.HasOne(d => d.ScIdVehiculoNavigation)
                    .WithMany(p => p.SolicitudCreditos)
                    .HasForeignKey(d => d.ScIdVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_solicitud_credito_vehiculo");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.VeId);

                entity.ToTable("vehiculo");

                entity.Property(e => e.VeId).HasColumnName("ve_id");

                entity.Property(e => e.VeAvaluo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ve_avaluo");

                entity.Property(e => e.VeCilindraje)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ve_cilindraje");

                entity.Property(e => e.VeMarcaId).HasColumnName("ve_marca_id");

                entity.Property(e => e.VeModelo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ve_modelo");

                entity.Property(e => e.VePlaca)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ve_placa");

                entity.Property(e => e.VeTipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ve_tipo");

                entity.HasOne(d => d.VeMarca)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.VeMarcaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_vehiculo_marca");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
