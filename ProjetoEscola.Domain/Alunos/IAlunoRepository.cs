using System.Threading.Tasks;

namespace ProjetoEscola.Domain.Alunos
{
    public interface IAlunoRepository
    {
        void Adicionar(Aluno aluno);

        void Atualizar(Aluno aluno);

        void Apagar(Aluno aluno);

        Task<bool> SalvarAlteracoes();
    }
}