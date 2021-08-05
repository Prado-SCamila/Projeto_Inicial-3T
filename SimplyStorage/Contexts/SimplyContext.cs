using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SimplyStorage.Domains;

#nullable disable

namespace SimplyStorage.Contexts
{
    public partial class SimplyContext : DbContext
    {
        public SimplyContext()
        {
        }

        public SimplyContext(DbContextOptions<SimplyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipamento> Equipamentos { get; set; }
        public virtual DbSet<Sala> Salas { get; set; }
        public virtual DbSet<TipoEquipamento> TipoEquipamentos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog= SimplyStorage; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Equipamento>(entity =>
            {
                entity.HasKey(e => e.CodEquipamento)
                    .HasName("PK__Equipame__C4C7E9D152B03F9F");

                entity.ToTable("Equipamento");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroPatrimonio).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.NumeroSerie).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.CodSalaNavigation)
                    .WithMany(p => p.Equipamentos)
                    .HasForeignKey(d => d.CodSala)
                    .HasConstraintName("FK__Equipamen__CodSa__2A4B4B5E");

                entity.HasOne(d => d.TipoEquipamentoNavigation)
                    .WithMany(p => p.Equipamentos)
                    .HasForeignKey(d => d.TipoEquipamento)
                    .HasConstraintName("FK__Equipamen__TipoE__2B3F6F97");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.HasKey(e => e.CodSala)
                    .HasName("PK__Sala__7DE9924ADCA07C7A");

                entity.ToTable("Sala");

                entity.Property(e => e.Metragem)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoEquipamento>(entity =>
            {
                entity.HasKey(e => e.CodTipo)
                    .HasName("PK__TipoEqui__752B12C0EC634618");

                entity.ToTable("TipoEquipamento");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.CodUsuario)
                    .HasName("PK__Usuario__FC30C2C4A3DA04DE");

                entity.ToTable("Usuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
