using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchoolWebAPI.V1.Dtos
{
    /// <summary>
    /// DTO utilizado para o registro de um aluno.
    /// </summary>
    public class AlunoRegistrarDto
    {
        /// <summary>
        /// Identificador único do aluno.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Número de matrícula do aluno.
        /// </summary>
        public int Matricula { get; set; }

        /// <summary>
        /// Primeiro nome do aluno.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Sobrenome do aluno.
        /// </summary>
        public string Sobrenome { get; set; }

        /// <summary>
        /// Número de telefone para contato do aluno.
        /// </summary>
        public string Telefone { get; set; }

        /// <summary>
        /// Data de nascimento do aluno.
        /// </summary>
        public DateTime DataDeNascimento { get; set; }
        
        /// <summary>
        /// Data em que o aluno foi matriculado. Valor padrão: data e hora atuais.
        /// </summary>
        public DateTime DataDeMatricula { get; set; } = DateTime.Now;
        
        /// <summary>
        /// Data de encerramento da matrícula do aluno, caso exista.
        /// </summary>
        public DateTime? DataDeEncerramento { get; set; } = null;
        
        /// <summary>
        /// Indica se o aluno está ativo. Valor padrão: true.
        /// </summary>
        public bool Ativo { get; set; } = true;
    }
}