using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchoolWebAPI.Data;
using SmartSchoolWebAPI.V1.Dtos;
using SmartSchoolWebAPI.model;

namespace SmartSchoolWebAPI.V1.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar as operações relacionadas aos alunos.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor da classe AlunoController.
        /// </summary>
        /// <param name="repo">Repositório de acesso aos dados.</param>
        /// <param name="mapper">Serviço de mapeamento de objetos.</param>
        public AlunoController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }
        /// <summary>
        /// Retorna todos os alunos cadastrados no sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /api/aluno
        ///
        /// </remarks>
        /// <returns>Lista de alunos.</returns>
        /// <response code="200">Retorna a lista de alunos</response>
        /// <response code="500">Erro interno no servidor</response>
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repo.GetAllAlunos(true);
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

        /// <summary>
        /// Retorna os dados de um aluno específico através do ID.
        /// </summary>
        /// <param name="id">Identificador do aluno.</param>
        /// <returns>Dados do aluno correspondente.</returns>
        /// <response code="200">Retorna os dados do aluno</response>
        /// <response code="400">Aluno não encontrado</response>
        /// <response code="500">Erro interno no servidor</response> 
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id);   
            if(aluno == null)
                return BadRequest("Aluno não encontrado!");
            var alunoDto = _mapper.Map<AlunoDto>(aluno);

            return Ok(alunoDto);
        }

        /// <summary>
        /// Cria um novo aluno no sistema.
        /// </summary>
        /// <param name="model">Dados para o cadastro do aluno.</param>
        /// <returns>Dados do aluno criado.</returns>
        /// <response code="201">Aluno criado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="500">Erro interno no servidor</response>
        [HttpPost]
        public IActionResult Post(AlunoRegistrarDto model)
        {
            var aluno = _mapper.Map<Aluno>(model);

            _repo.Add(aluno);
            if(_repo.SaveChanges())
                return Created($"/api/aluno/{aluno.Id}", _mapper.Map<AlunoDto>(aluno));

            return BadRequest("Aluno não cadastrado!");
        }

        /// <summary>
        /// Atualiza completamente os dados de um aluno existente.
        /// </summary>
        /// <param name="id">Identificador do aluno a ser atualizado.</param>
        /// <param name="model">Novos dados do aluno.</param>
        /// <returns>Dados do aluno atualizado.</returns>
        /// <response code="201">Aluno atualizado com sucesso</response>
        /// <response code="400">Aluno não encontrado ou dados inválidos</response>
        /// <response code="500">Erro interno no servidor</response>
        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegistrarDto model)
        {
            var aluno = _repo.GetAlunoById(id);
            if(aluno == null) return BadRequest("Aluno não encontrado");
            
            _mapper.Map(model, aluno);

            _repo.Update(aluno);
            if(_repo.SaveChanges())
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));

            return BadRequest("Aluno não atualizado!");
        }

        /// <summary>
        /// Atualiza parcialmente os dados de um aluno existente.
        /// </summary>
        /// <param name="id">Identificador do aluno a ser atualizado.</param>
        /// <param name="model">Dados parciais do aluno.</param>
        /// <returns>Dados do aluno atualizado.</returns>
        /// <response code="201">Aluno atualizado com sucesso</response>
        /// <response code="400">Aluno não encontrado ou dados inválidos</response>
        /// <response code="500">Erro interno no servidor</response>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoRegistrarDto model)
        {
            var aluno = _repo.GetAlunoById(id);
            if(aluno == null) return BadRequest("Aluno não encontrado");
            
            _mapper.Map(model, aluno);

            _repo.Update(aluno);
            if(_repo.SaveChanges())
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));

            return BadRequest("Aluno não atualizado!");
        }

        /// <summary>
        /// Exclui um aluno do sistema.
        /// </summary>
        /// <param name="id">Identificador do aluno a ser excluído.</param>
        /// <response code="204">Aluno excluído com sucesso</response>
        /// <response code="400">Aluno não encontrado</response>
        /// <response code="500">Erro interno no servidor</response>  
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if(aluno == null) return BadRequest("Aluno não encontrado");
             
            _repo.Delete(aluno);
            if(_repo.SaveChanges())
                return Ok("Aluno deletado!");

            return BadRequest("Aluno não deletado!");
        }
    }
}