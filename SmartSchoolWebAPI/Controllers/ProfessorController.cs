using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchoolWebAPI.Data;
using SmartSchoolWebAPI.model;

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
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if(prof == null)
                return BadRequest("Professor não encontrado!");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (prof == null)
                return BadRequest("Professor não encontrado!");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if(professor == null)
                return BadRequest("Professor não encontrado!");
            _context.Remove(professor);
            _context.SaveChanges();
            return Ok();
        }
    }
}