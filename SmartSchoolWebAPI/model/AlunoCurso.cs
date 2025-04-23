using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchoolWebAPI.model
{
    public class AlunoCurso
    {
        public AlunoCurso() { }
        
        public AlunoCurso(int alunoId, int cursoId) 
        {
            this.AlunoId = alunoId;
            this.CursoId = cursoId;
   
        }
        
        public DateTime DataDeInicio { get; set; } = DateTime.Now;
        public DateTime? DataDeFim { get; set; }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}