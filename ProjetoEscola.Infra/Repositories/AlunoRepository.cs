using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Domain.Alunos;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Infrastructure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private DataContext _dataContext { get; }

        public AlunoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Adicionar(Aluno aluno)
        {
            _dataContext.Add(aluno);
        }

        public void Apagar(Aluno aluno)
        {
            _dataContext.Remove(aluno);
        }

        public void Atualizar(Aluno aluno)
        {
            _dataContext.Update(aluno);
        }

        public async Task<bool> SalvarAlteracoes()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<Aluno[]> ListarTodos(bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = _dataContext.Alunos;

            if (incluirProfessor)
                query = query
                        .Include(a => a.Professor);

            query = query
                    .AsNoTracking()
                    .OrderBy(a => a.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Aluno[]> ListarPorProfessorId(int professorId, bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = _dataContext.Alunos;

            if (incluirProfessor)
                query = query
                        .Include(a => a.Professor);

            query = query
                    .AsNoTracking()
                    .Where(a => a.ProfessorId == professorId)
                    .OrderBy(a => a.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Aluno> ListarPorId(int alunoId, bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = _dataContext.Alunos;

            if (incluirProfessor)
                query = query
                        .Include(a => a.Professor);

            query = query
                    .AsNoTracking()
                    .Where(a => a.Id == alunoId);

            return await query.FirstOrDefaultAsync();
        }
    }
}