using System.Threading.Tasks;

namespace ProjetoEscola.Domain.Professores
{
    public interface IProfessorRepository
    {
        void Adicionar(Professor professor);

        void Atualizar(Professor professor);

        void Apagar(Professor professor);

        Task<bool> SalvarAlteracoes();
    }
}