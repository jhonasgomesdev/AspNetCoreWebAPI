using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSchoolWebAPI.Helpers;
using SmartSchoolWebAPI.model;

namespace SmartSchoolWebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;
        public Repository(SmartContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0 );
        }

        public async Task<PageList<Aluno>> GetAllAlunosAsync(
            PageParams pageParams,
            bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            
            if(includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                                        .ThenInclude(ad => ad.Disciplina)
                                        .ThenInclude(d => d.Professor);
            }
            
            query = query.AsNoTracking().OrderBy(a => a.Id);

            if(!string.IsNullOrEmpty(pageParams.Nome))
            {
                

                query = query.Where(aluno => aluno.Nome
                                                  .ToUpper()
                                                  .Contains(pageParams.Nome.ToUpper()) ||
                                            aluno.Sobrenome
                                                  .ToUpper()
                                                  .Contains(pageParams.Nome.ToUpper()));
            }

            if(pageParams.Matricula > 0)
            {
                query = query.Where(aluno => aluno.Matricula == pageParams.Matricula);
            }

            if (pageParams.Ativo != null)
            {
                query = query.Where(aluno => aluno.Ativo == (pageParams.Ativo != 0));
            }

            if (pageParams.OrderByNome != null)
            {
                pageParams.OrderByMatricula = null;
                pageParams.OrderByAtivo = null;
                query = pageParams.OrderByNome == true
                    ? query.OrderBy(aluno => aluno.Nome)
                    : query.OrderByDescending(aluno => aluno.Nome);
            }
            else if (pageParams.OrderByAtivo != null)
            {
                pageParams.OrderByNome = null;
                pageParams.OrderByMatricula = null;
                query = pageParams.OrderByAtivo == false
                    ? query.OrderBy(aluno => aluno.Ativo)
                    : query.OrderByDescending(aluno => aluno.Ativo);
            }
            else if (pageParams.OrderByMatricula != null)
            {
                pageParams.OrderByNome = null;
                pageParams.OrderByAtivo = null;
                query = pageParams.OrderByMatricula == true
                    ? query.OrderBy(aluno => aluno.Matricula)
                    : query.OrderByDescending(aluno => aluno.Matricula);
            }

            return await PageList<Aluno>.CreateAsync(query, pageParams.pageNumber, pageParams.PageSize);
        }

        public Aluno[] GetAllAlunos(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            
            if(includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                                        .ThenInclude(ad => ad.Disciplina)
                                        .ThenInclude(d => d.Professor);
            }
            
            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            
            if(includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                                        .ThenInclude(ad => ad.Disciplina)
                                        .ThenInclude(d => d.Professor);
            }
            
            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(aluno => aluno.AlunosDisciplinas
                         .Any(ad => ad.DisciplinaId == disciplinaId));

            return query.ToArray();
        }

        public Aluno GetAlunoById(int alunoId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            
            if(includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                                        .ThenInclude(ad => ad.Disciplina)
                                        .ThenInclude(d => d.Professor);
            }
            
            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(aluno => aluno.Id == alunoId);

            return query.FirstOrDefault();
        }

        public Professor[] GetAllProfessores(bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;
            if(includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                                            .ThenInclude(d => d.AlunosDisciplinas)
                                            .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking()
                         .OrderBy(p => p.Id);
            
            return query.ToArray();
        }

        public Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                             .ThenInclude(d => d.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking()
                         .OrderBy(aluno => aluno.Id)
                         .Where(aluno => aluno.Disciplinas
                         .Any(d => d.AlunosDisciplinas
                         .Any(ad => ad.DisciplinaId == disciplinaId)));

            return query.ToArray();
        }

        public Professor GetProfessorById(int professorId, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeAlunos)
            {
                query = query.Include(a => a.Disciplinas)
                             .ThenInclude(d => d.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking()
                         .OrderBy(p => p.Id)
                         .Where(professor => professor.Id == professorId);
            
            return query.FirstOrDefault();
        }

    }
}