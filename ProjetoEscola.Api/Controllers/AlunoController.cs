using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Domain.Alunos;
using System;
using System.Threading.Tasks;

namespace ProjetoEscola.Api.Controllers
{
    [Route("api/aluno")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public IAlunoRepository _repository { get; }

        public AlunoController(IAlunoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var result = await _repository.ListarTodos(true);

                return Ok(result);
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        [HttpGet("{alunoid}")]
        public async Task<IActionResult> ListarPorId(int alunoid)
        {
            try
            {
                var result = await _repository.ListarPorId(alunoid, true);

                return Ok(result);
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        [HttpGet("professor/{professorid}")]
        public async Task<IActionResult> ListarPorProfessorId(int professorid)
        {
            try
            {
                var result = await _repository.ListarPorProfessorId(professorid, true);

                return Ok(result);
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(Aluno aluno)
        {
            try
            {
                _repository.Adicionar(aluno);

                if (await _repository.SalvarAlteracoes())
                    return Created($"/api/aluno/{aluno.Id}", aluno);
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou.");
            }

            return BadRequest();
        }

        [HttpPut("{alunoid}")]
        public async Task<IActionResult> Atualizar(int alunoid, Aluno aluno)
        {
            try
            {
                var exite = await _repository.ListarPorId(alunoid);
                if (exite == null) return NotFound();

                aluno.Id = alunoid;

                _repository.Atualizar(aluno);

                if (await _repository.SalvarAlteracoes())
                {
                    exite = await _repository.ListarPorId(alunoid, true);

                    return Created($"/api/aluno/{aluno.Id}", exite);
                }
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            };

            return BadRequest();
        }

        [HttpDelete("{alunoid}")]
        public async Task<IActionResult> Apagar(int alunoid)
        {
            try
            {
                var exite = await _repository.ListarPorId(alunoid);
                if (exite == null) return NotFound();

                _repository.Apagar(exite);

                if (await _repository.SalvarAlteracoes())
                {
                    return Ok();
                }
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            };

            return BadRequest();
        }
    }
}