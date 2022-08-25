using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{professorid}")]
        public IActionResult Get(int professorId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(int professorId)
        {
             return Ok();
        }

        [HttpPut("{professorid}")]
        public IActionResult Put(int professorId)
        {
              return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int professorId)
        {
              return Ok();
        }
    }
}