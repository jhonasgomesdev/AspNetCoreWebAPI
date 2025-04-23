using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchoolWebAPI.Dtos
{
    public class AlunoRegistrarDto
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public DateTime DataDeMatricula { get; set; } = DateTime.Now;
        public DateTime? DataDeEncerramento { get; set; } = null;
        public bool Ativo { get; set; } = true;
    }
}