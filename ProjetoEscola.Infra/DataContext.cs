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

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Professor>()
        //        .HasData(
        //          new List<Professor>()
        //          {
        //              new Professor()
        //              {
        //                  Id = 1,
        //                  Nome= "Paulo"
        //              },
        //              new Professor()
        //              {
        //                  Id = 2,
        //                  Nome= "Marcia"
        //              },
        //              new Professor()
        //              {
        //                  Id = 3,
        //                  Nome= "Odete"
        //              },
        //          }
        //      );

        //    builder.Entity<Aluno>()
        //        .HasData(
        //          new List<Aluno>()
        //          {
        //              new Aluno()
        //              {
        //                  Id = 1,
        //                  Nome= "Guilherme",
        //                  Sobrenome= "Lopes",
        //                  Nascimento= "07/04/1991",
        //                  ProfessorId = 1
        //              },
        //              new Aluno()
        //              {
        //                  Id = 2,
        //                  Nome= "Evelin",
        //                  Sobrenome= "Silva",
        //                  Nascimento= "25/04/1989",
        //                  ProfessorId = 2
        //              },
        //              new Aluno()
        //              {
        //                  Id = 3,
        //                  Nome= "João",
        //                  Sobrenome= "Silva",
        //                  Nascimento= "10/12/2018",
        //                  ProfessorId = 3
        //              },
        //          }
        //      );
        //}
    }
}