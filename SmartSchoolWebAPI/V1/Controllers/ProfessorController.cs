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
    /// Controller responsável por gerenciar operações relacionadas aos professores.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase
    {

        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        
        /// <summary>
        /// Construtor da classe ProfessorController.
        /// </summary>
        /// <param name="repo">Repositório de acesso aos dados.</param>
        /// <param name="mapper">Serviço de mapeamento de objetos.</param>
        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todos os professores cadastrados.
        /// </summary>
        /// <returns>Lista de professores.</returns>
        /// <response code="200">Retorna a lista de professores.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repo.GetAllProfessores(true);
            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
        }

        /// <summary>
        /// Retorna os dados de um professor específico pelo ID.
        /// </summary>
        /// <param name="id">Identificador do professor.</param>
        /// <returns>Dados do professor.</returns>
        /// <response code="200">Retorna os dados do professor.</response>
        /// <response code="400">Professor não encontrado.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if(professor == null)
                return BadRequest("Professor não encontrado!");
            var professorDto = _mapper.Map<ProfessorDto>(professor);

            return Ok(professorDto);
        }
        
        /// <summary>
        /// Cria um novo professor no sistema.
        /// </summary>
        /// <param name="model">Dados para o cadastro do professor.</param>
        /// <returns>Dados do professor criado.</returns>
        /// <response code="201">Professor criado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDto model)
        {
            var professor = _mapper.Map<Professor>(model);

            _repo.Add(professor);

            if(_repo.SaveChanges())
                return Created($"/api/professor/{professor.Id}",_mapper.Map<ProfessorDto>(professor));

            return BadRequest("Professor não cadastrado!");
        }

        /// <summary>
        /// Atualiza completamente os dados de um professor.
        /// </summary>
        /// <param name="id">Identificador do professor.</param>
        /// <param name="model">Novos dados do professor.</param>
        /// <returns>Dados do professor atualizado.</returns>
        /// <response code="201">Professor atualizado com sucesso.</response>
        /// <response code="400">Professor não encontrado ou dados inválidos.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistrarDto model)
        {
            var professor = _repo.GetProfessorById(id);
            if(professor == null)
                return BadRequest("Professor não encontrado!");

            _mapper.Map(model, professor);
            
            _repo.Update(professor);

            if(_repo.SaveChanges())
                return Created($"/api/professor/{professor.Id}", _mapper.Map<ProfessorDto>(professor));

            return BadRequest("Professor não atualizado!");
        }

        /// <summary>
        /// Atualiza parcialmente os dados de um professor.
        /// </summary>
        /// <param name="id">Identificador do professor.</param>
        /// <param name="model">Dados parciais do professor.</param>
        /// <returns>Dados do professor atualizado.</returns>
        /// <response code="201">Professor atualizado com sucesso.</response>
        /// <response code="400">Professor não encontrado ou dados inválidos.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorRegistrarDto model)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null)
                return BadRequest("Professor não encontrado!");

            _mapper.Map(model, professor);
            
            _repo.Update(professor);

            if(_repo.SaveChanges())
                return Created($"/api/professor/{professor.Id}", _mapper.Map<ProfessorDto>(professor));

            return BadRequest("Professor não atualizado!");
        }

        /// <summary>
        /// Exclui um professor do sistema.
        /// </summary>
        /// <param name="id">Identificador do professor.</param>
        /// <response code="204">Professor excluído com sucesso.</response>
        /// <response code="400">Professor não encontrado.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if(professor == null)
                return BadRequest("Professor não encontrado!");
           
           _repo.Delete(professor);
            if(_repo.SaveChanges())
                return Ok("Professor deletado!");
            return BadRequest("Professor não deletado!");
        }
    }
}