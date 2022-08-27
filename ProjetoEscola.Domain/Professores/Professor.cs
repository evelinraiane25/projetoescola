using ProjetoEscola.Domain.Alunos;
using System.Collections.Generic;

namespace ProjetoEscola.Domain.Professores
{
    public class Professor
    {
        public Professor()
        {
            Alunos = new List<Aluno>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}