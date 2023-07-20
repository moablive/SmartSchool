using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno()
            {
                Id = 1,
                Nome = "Guilherme",
                Sobrenome = "A",
                Telefone = "123"
            },

            new Aluno()
            {
                Id = 2,
                Nome = "PEDRO",
                Sobrenome = "B",
                Telefone = "456"
            },

            new Aluno()
            {
                Id = 3,
                Nome = "PAULO",
                Sobrenome = "C",
                Telefone = "789"
            },

        };

        public AlunoController(){}
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        //api/aluno/byId/1
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno inexistente");

            return Ok(aluno);
        }

        //api/aluno/byName?nome=NOME&sobrenome=SOBRENOME
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string Sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => 
                a.Nome.Contains(nome) && a.Sobrenome.Contains(Sobrenome)
                );
            if (aluno == null) return BadRequest("Aluno inexistente");

            return Ok(aluno);
        }

        //api/aluno/
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        //api/aluno/
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        //api/aluno/
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        //api/aluno/
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
