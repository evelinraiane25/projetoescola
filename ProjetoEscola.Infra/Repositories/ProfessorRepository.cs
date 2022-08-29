using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Domain.Professores;
using System.Linq;
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

        public async Task<Professor[]> ListarTodos(bool incluirAluno)
        {
            IQueryable<Professor> query = _dataContext.Professores;

            if (incluirAluno)
                query = query
                        .Include(p => p.Alunos);

            query = query
                    .AsNoTracking()
                    .OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Professor> ListarPorId(int professorId, bool incluirAluno)
        {
            IQueryable<Professor> query = _dataContext.Professores;

            if (incluirAluno)
                query = query
                        .Include(p => p.Alunos);

            query = query
                    .AsNoTracking()
                    .Where(p => p.Id == professorId);

            return await query.FirstOrDefaultAsync();
        }
    }
}