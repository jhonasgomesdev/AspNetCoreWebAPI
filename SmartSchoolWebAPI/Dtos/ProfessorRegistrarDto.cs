using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchoolWebAPI.Dtos
{
    public class ProfessorRegistrarDto
    {
        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataDeRegistro { get; set; } = DateTime.Now;
        public DateTime? DataDeEncerramento { get; set; } = null;
        public bool Ativo { get; set; } = true;
    }
}