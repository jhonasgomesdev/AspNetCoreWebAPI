using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchoolWebAPI.model
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina() { }
        
        public AlunoDisciplina(int alunoId, int disciplinaId) 
        {
            this.AlunoId = alunoId;
            this.DisciplinaId = disciplinaId;
   
        }
        
        public DateTime DataDeInicio { get; set; } = DateTime.Now;
        public DateTime? DataDeFim { get; set; }
        public int? Nota { get; set; } = null;
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}