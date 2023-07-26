using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System.Linq;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;
        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        //api/professor
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        //api/professor/byId/1
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var prof = _context.Professores.FirstOrDefault(p => p.Id == id);
            if (prof == null) return BadRequest("Professor inexistente");

            return Ok(prof);
        }

        //api/professor/byName?nome=NOME
        [HttpGet("byName")]
        public IActionResult GetByName(string nome)
        {
            var prof = _context.Professores.FirstOrDefault
            (p => p.Nome.Contains(nome));
            if (prof == null) return BadRequest("Professor inexistente");

            return Ok(prof);
        }

        //api/professor/
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        //api/professor/
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (prof == null) return BadRequest("Professor não Localizado");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        //api/professor/
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (prof == null) return BadRequest("Professor não Localizado");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        //api/professor/
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _context.Professores.FirstOrDefault(p => p.Id == id);
            if (prof == null) return BadRequest("Deletando Professor não Localizado");

            //Variavel Local PRO de (PROFESSOR)
            _context.Remove(prof);
            _context.SaveChanges();
            return Ok();
        }
    }
}
