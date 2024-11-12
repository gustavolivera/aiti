using Domain.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EF
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        internal DbSet<Usuario> Usuarios { get; set; }
        internal DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Chamado> Chamados { get; set; }
        internal DbSet<Complemento> Complementos { get; set; }
        internal DbSet<Funcao> Funcoes { get; set; }
        internal DbSet<Motivo> Motivos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        internal DbSet<Setor> Setores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chamado>(entity =>
            {
                // Configuração de chave primária
                entity.HasKey(e => e.Id);

                // Relacionamento com Pessoa (um-para-muitos)
                entity.HasOne(e => e.Pessoa)
                    .WithMany()
                    .HasForeignKey(e => e.PessoaId)
                    .OnDelete(DeleteBehavior.Restrict); // Define o comportamento de exclusão

                // Relacionamento com Motivo (um-para-muitos)
                entity.HasOne(e => e.Motivos)
                    .WithMany()
                    .HasForeignKey(e => e.MotivoId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relacionamento com Complemento (um-para-muitos)
                entity.HasOne(e => e.Complemento)
                    .WithMany()
                    .HasForeignKey(e => e.ComplementoId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relacionamento com Atendimento (um-para-muitos)
                entity.HasMany(e => e.Atendimento)
                    .WithOne()
                    .HasForeignKey("ChamadoId") // Defina o nome da coluna de chave estrangeira em Atendimento
                    .OnDelete(DeleteBehavior.Cascade);

                // Propriedades simples
                entity.Property(e => e.Urgencia)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.Observacoes)
                    .HasMaxLength(500); // Defina o tamanho máximo conforme necessário

                entity.Property(e => e.DataHora_inicio)
                    .IsRequired();

                entity.Property(e => e.DataHora_fim)
                    .IsRequired();
            });

            modelBuilder.Entity<Usuario>(t =>
            {
                t.ToTable("Usuarios");
                t.Property(t => t.Id).HasColumnType("int").
                    IsRequired().ValueGeneratedOnAdd();
                t.Property(t => t.Login).HasColumnType("varchar(20)").IsRequired();
                t.Property(t => t.Senha).HasColumnType("varchar(10)").IsRequired();
            });
            modelBuilder.Entity<Motivo>(t =>
            {
                t.ToTable("Motivos");
                t.Property(t => t.Id).HasColumnType("int").
                    IsRequired().ValueGeneratedOnAdd();
                t.Property(t => t.Nome).HasColumnType("varchar(50)").IsRequired();
            });
            modelBuilder.Entity<Complemento>(t =>
            {
                t.ToTable("Complementos");
                t.Property(t => t.Id).HasColumnType("int").
                    IsRequired().ValueGeneratedOnAdd();
                t.Property(t => t.Nome).HasColumnType("varchar(50)").IsRequired();
                t.Property(t => t.MotivoId).HasColumnType("int").IsRequired();
                t.HasOne(t => t.Motivo).
                   WithMany(t => t.Complementos).
                   OnDelete(DeleteBehavior.NoAction).//Não permite remoção em cascata
                   IsRequired();
            });
            modelBuilder.Entity<Setor>(t =>
            {
                t.ToTable("Setores");
                t.Property(t => t.Id).HasColumnType("int").
                    IsRequired().ValueGeneratedOnAdd();
                t.Property(t => t.Nome).HasColumnType("varchar(50)").IsRequired();
            });
            modelBuilder.Entity<Funcao>(t =>
            {
                t.ToTable("Funcoes");
                t.Property(t => t.Id).HasColumnType("int").
                    IsRequired().ValueGeneratedOnAdd();
                t.Property(t => t.Nome).HasColumnType("varchar(50)").IsRequired();
                t.Property(t => t.SetorId).HasColumnType("int").IsRequired();
                t.HasOne(t => t.Setor).
                   WithMany(t => t.Funcoes).
                   OnDelete(DeleteBehavior.NoAction).//Não permite remoção em cascata
                   IsRequired();
            });
        }
    }
}
