using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchoolWebAPI.model
{
    public class Professor
    {
        public Professor(int id,
                        int registro,
                        string nome,
                        string sobrenome) 
        {
            this.Id = id;
            this.Registro = registro;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
   
        }
        public Professor(){ }
        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataDeRegistro { get; set; } = DateTime.Now;
        public DateTime? DataDeEncerramento { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}