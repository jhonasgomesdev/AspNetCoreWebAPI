using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchoolWebAPI.model
{
    public class Aluno
    {
        public Aluno() { }
        public Aluno(int id, 
                    int matricula,
                    string nome,
                    string sobrenome,
                    string telefone,
                    DateTime dataDeNascimento) 
        {
            this.Id = id;
            this.Matricula = matricula;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Telefone = telefone;
            this.DataDeNascimento = dataDeNascimento;
        }

        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public DateTime DataDeMatricula { get; set; } = DateTime.Now;
        public DateTime? DataDeEncerramento { get; set; } = null;
        public bool Ativo { get; set; } = true;

        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
        
    }
}