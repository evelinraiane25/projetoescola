using ProjetoEscola.Domain.Professores;
using System.Threading.Tasks;

namespace ProjetoEscola.Infrastructure.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private DataContext _dataContext { get; }

        public ProfessorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Adicionar(Professor professor)
        {
            _dataContext.Add(professor);
        }

        public void Apagar(Professor professor)
        {
            _dataContext.Remove(professor);
        }

        public void Atualizar(Professor professor)
        {
            _dataContext.Update(professor);
        }

        public async Task<bool> SalvarAlteracoes()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}