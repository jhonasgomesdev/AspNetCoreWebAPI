using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SmartSchoolWebAPI.Data;
using SmartSchoolWebAPI.model;
using Microsoft.EntityFrameworkCore;

namespace SmartSchoolWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;
        public readonly IRepository _repo;

        public AlunoController(SmartContext context,
                               IRepository repo)
        {
            _repo = repo;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);   
            if(aluno == null)
                return BadRequest("Aluno não encontrado!");
            return Ok(aluno);
        }
        [HttpGet("byId/{id}")]
        public IActionResult GetId(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);   
            if(aluno == null)
                return BadRequest("Aluno não encontrado!");
            return Ok(aluno);
        }
        [HttpGet("{nome}")]
        public IActionResult GetByName(string nome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome));
            if(aluno == null)
                return BadRequest("Aluno não encontrado!");
            return Ok(aluno);
        }
        [HttpGet("byId")]
        public IActionResult GetByIdQuerry(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);   
            if(aluno == null)
                return BadRequest("Aluno não encontrado!");
            return Ok(aluno);
        }
        [HttpGet("byName")]
        public IActionResult GetByNameQuerry(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if(aluno == null)
                return BadRequest("Aluno não encontrado!");
            return Ok(aluno);
        }
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if(_repo.SaveChanges())
                return Ok(aluno);
            return BadRequest("Aluno não cadastrado!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id );
            if(alu == null) return BadRequest("Aluno não encontrado");
            
            _repo.Update(aluno);
            if(_repo.SaveChanges())
                return Ok(aluno);
            return BadRequest("Aluno não atualizado!");
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id );
            if(alu == null) return BadRequest("Aluno não encontrado");
            
            _repo.Update(aluno);
            if(_repo.SaveChanges())
                return Ok(aluno);
            return BadRequest("Aluno não cadastrado!");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id );
            if(aluno == null) return BadRequest("Aluno não encontrado");
             
            _repo.Delete(aluno);
            if(_repo.SaveChanges())
                return Ok("Aluno deletado!");
            return BadRequest("Aluno não deletado!");
        }
    }
}