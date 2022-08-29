using System.Threading.Tasks;

namespace ProjetoEscola.Domain.Professores
{
    public interface IProfessorRepository
    {
        void Adicionar(Professor professor);

        void Atualizar(Professor professor);

        void Apagar(Professor professor);

        Task<bool> SalvarAlteracoes();

        Task<Professor[]> ListarTodos(bool incluirAluno = false);

        Task<Professor> ListarPorId(int professorId, bool incluirAluno = false);
    }
}