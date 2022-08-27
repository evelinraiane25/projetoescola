using ProjetoEscola.Domain.Alunos;
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
    }
}