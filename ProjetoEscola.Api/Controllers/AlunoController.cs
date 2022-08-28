using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Domain.Alunos;
using System;
using System.Threading.Tasks;

namespace ProjetoEscola.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public IAlunoRepository _repository { get; }

        public AlunoController(IAlunoRepository repository)
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

        [HttpGet("{alunoid}")]
        public IActionResult Get(int alunoId)
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
        public async Task<IActionResult> Post(Aluno aluno)
        {
            try
            {
                _repository.Adicionar(aluno);

                if (await _repository.SalvarAlteracoes())
                {
                    return Created($"/api/aluno/{aluno.Id}", aluno);
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "Não foi possivel adicionar o aluno.");
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou.");
            }
        }

        [HttpPut("{alunoid}")]
        public IActionResult Put(int alunoId)
        {
            try
            {
                return Ok();
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            };
        }

        [HttpDelete]
        public IActionResult Delete(int alunoId)
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