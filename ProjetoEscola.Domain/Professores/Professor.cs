using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoEscola.Domain.Professores
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Aluno> Alunos { get; set; }

    }
}
