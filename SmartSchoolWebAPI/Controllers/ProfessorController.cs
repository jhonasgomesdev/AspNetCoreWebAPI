using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchoolWebAPI.Data;

namespace SmartSchoolWebAPI.Controllers
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if(professor == null)
                return BadRequest("Professor não encontrado!");
            return Ok(professor);
        }
        [HttpGet("byId/{id}")]
        public IActionResult ById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if(professor == null)
                return BadRequest("Professor não encontrado!");
            return Ok(professor);
        }
        [HttpGet("{nome}")]
        public IActionResult GetByName(string nome)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Nome.Contains(nome));
            if(professor == null)
                return BadRequest("Professor não encontrado!");
            return Ok(professor);
        }
        [HttpGet("byId")]
        public IActionResult GetByIdQuerry(int id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);   
            if(professor == null)
                return BadRequest("Aluno não encontrado!");
            return Ok(professor);
        }
        [HttpGet("byName")]
        public IActionResult GetByNameQuerry(string nome)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Nome.Contains(nome));
            if(professor == null)
                return BadRequest("Aluno não encontrado!");
            return Ok(professor);
        }
    }
}