using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Domain.Professores;
using System;
using System.Threading.Tasks;

namespace ProjetoEscola.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        public IProfessorRepository _repository { get; }

        public ProfessorController(IProfessorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok();
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        [HttpGet("{professorid}")]
        public IActionResult Get(int professorId)
        {
            try
            {
                return Ok();
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Professor professor)
        {
            try
            {
                _repository.Adicionar(professor);

                if (await _repository.SalvarAlteracoes())
                {
                    return Created($"/api/professor/{professor.Id}", professor);
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "Não foi possivel adicionar o professor.");
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados.");
            }
        }

        [HttpPut("{professorid}")]
        public IActionResult Put(int professorId, Professor professor)
        {
            try
            {
                _repository.Atualizar(professor);

                //if (await _repository.SalvarAlteracoes())
                //{
                //    return Created($"/api/professor/{professor.Id}", professor);
                //}

                return StatusCode(StatusCodes.Status500InternalServerError, "Não foi possivel adicionar o professor.");
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados.");
            }
        }

        [HttpDelete]
        public IActionResult Delete(int professorId)
        {
            try
            {
                return Ok();
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }
    }
}