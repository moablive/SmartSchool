using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.V1.Dtos;
using SmartSchool.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartSchool.API.V1.Controllers
{
    /// <summary>
    /// V1 Professor Controller 
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase
    {
     
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        //api/professor
        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repo.GetAllProfessores(true);
            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
        }
        
        //api/professor/getRegister
        [HttpGet("getRegister")]
        public IActionResult getRegister()
        {
            return Ok(new ProfessorRegistrarDto());
        }

        //api/professor/
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var profesor = _repo.GetProfessorById(id, true);
            if (profesor == null) return BadRequest("O Professor não Localizado");

            var ProfessorDto = _mapper.Map<ProfessorDto>(profesor);
            return Ok(profesor);
        }

        //api/professor/
        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDto model)
        {
            var professor = _mapper.Map<Professor>(model);

            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }
            return BadRequest("Professor não Cadastrado");
        }

        //api/professor/
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorDto model)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("Professor não Localizado");

            _mapper.Map(model, professor);

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }
            return BadRequest("Professor não Atualizado");
        }

        //api/professor/
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorDto model)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("Professor não Localizado");
            
            _mapper.Map(model, professor);

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("Professor não Atualizado");
        }

        //api/professor/
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("Professor não Localizado");

            _repo.Delete(professor);
            if (_repo.SaveChanges())
            {
                return Ok("Professor Deletado");
            }
            return BadRequest("Professor não Deletado");
        }
    }
}
