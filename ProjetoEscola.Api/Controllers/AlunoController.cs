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
    public class AlunoController :  ControllerBase
    {
        public AlunoController()
        {

        }
        [HttpGet]

        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{alunoid}")]
        public IActionResult Get(int alunoId)
        {
            return Ok();
        }
        
        [HttpPost]
        public IActionResult Post()
        {
             return Ok();
        }

        [HttpPut("{alunoid}")]
        public IActionResult Put(int alunoId)
        { 
             return Ok();
        }

        [HttpDelete]
         public IActionResult Delete(int alunoId)
        {
             return Ok();
        }
    }
}