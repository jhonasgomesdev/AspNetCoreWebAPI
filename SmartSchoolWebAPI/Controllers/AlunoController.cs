using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SmartSchoolWebAPI.model;

namespace SmartSchoolWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>() {
            new Aluno() 
            {
                Id = 1,
                Nome = "Jhonas",
                Sobrenome = "Gomes",
                Telefone = "11111111111"
            },
            new Aluno() 
            {
                Id = 2,
                Nome = "Jhonnatan",
                Sobrenome = "Muniz",
                Telefone = "22222222222"
            },
            new Aluno() 
            {
                Id = 3,
                Nome = "Luiza",
                Sobrenome = "Favacho",
                Telefone = "33333333333"
            }
        };

        public AlunoController(){ }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);   
            if(aluno == null)
                return BadRequest("Aluno não encontrado!");
            return Ok(aluno);
        }
        [HttpGet("{nome}")]
        public IActionResult GetByName(string nome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome));
            if(aluno == null)
                return BadRequest("Aluno não encontrado!");
            return Ok(aluno);
        }
        [HttpGet("byId")]
        public IActionResult GetByIdQuerry(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);   
            if(aluno == null)
                return BadRequest("Aluno não encontrado!");
            return Ok(aluno);
        }
        [HttpGet("byName")]
        public IActionResult GetByNameQuerry(string nome, string sobrenome)
        {
            var aluno= Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if(aluno == null)
                return BadRequest("Aluno não encontrado!");
            return Ok(aluno);
        }
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(); 
        }
    }
}