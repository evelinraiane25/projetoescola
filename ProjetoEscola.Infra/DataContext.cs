using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Domain.Alunos;
using ProjetoEscola.Domain.Professores;
using System.Collections.Generic;

namespace ProjetoEscola.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(p => p.Id);
            });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(p => p.Id);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}