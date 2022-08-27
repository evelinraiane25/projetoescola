using ProjetoEscola.Domain.Professores;

namespace ProjetoEscola.Domain.Alunos
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Nascimento { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}