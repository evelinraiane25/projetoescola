using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Domain.Professores;
using System;
using System.Threading.Tasks;

namespace ProjetoEscola.Api.Controllers
{
    [Route("api/professores")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        public IProfessorRepository _repository { get; }

        public ProfessorController(IProfessorRepository repository)
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

        [HttpGet("{professorid}")]
        public async Task<IActionResult> ListarPorId(int professorid)
        {
            try
            {
                var result = await _repository.ListarPorId(professorid, true);

                return Ok(result);
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(Professor professor)
        {
            try
            {
                _repository.Adicionar(professor);

                if (await _repository.SalvarAlteracoes())
                    return Created($"/api/professor/{professor.Id}", professor);
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados.");
            }

            return BadRequest();
        }

        [HttpPut("{professorid}")]
        public async Task<IActionResult> Atualizar(int professorid, Professor professor)
        {
            try
            {
                var exite = await _repository.ListarPorId(professorid);
                if (exite == null) return NotFound();

                professor.Id = professorid;

                _repository.Atualizar(professor);

                if (await _repository.SalvarAlteracoes())
                {
                    exite = await _repository.ListarPorId(professorid, true);

                    return Created($"/api/professor/{professor.Id}", exite);
                }
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            };

            return BadRequest();
        }

        [HttpDelete("{professorid}")]
        public async Task<IActionResult> Apagar(int professorid)
        {
            try
            {
                var exite = await _repository.ListarPorId(professorid);
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