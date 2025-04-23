using System;

namespace SmartSchoolWebAPI.Dtos
{
    public class AlunoDto
    {

        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int Idade { get; set; }
        public DateTime DataDeMatricula { get; set; }
        public bool Ativo { get; set; }
        
    }
}