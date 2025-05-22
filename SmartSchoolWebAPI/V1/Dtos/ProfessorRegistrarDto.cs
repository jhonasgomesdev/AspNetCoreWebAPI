using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchoolWebAPI.V1.Dtos
{
    /// <summary>
    /// DTO utilizado para o registro de um professor.
    /// </summary>
    public class ProfessorRegistrarDto
    {
        /// <summary>
        /// Identificador único do professor.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Número de registro funcional do professor.
        /// </summary>
        public int Registro { get; set; }

        /// <summary>
        /// Primeiro nome do professor.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Sobrenome do professor.
        /// </summary>
        public string Sobrenome { get; set; }

        /// <summary>
        /// Número de telefone para contato do professor.
        /// </summary>
        public string Telefone { get; set; }

        /// <summary>
        /// Data em que o professor foi registrado. Valor padrão: data e hora atuais.
        /// </summary>
        public DateTime DataDeRegistro { get; set; } = DateTime.Now;
        
        /// <summary>
        /// Data de encerramento do vínculo do professor, caso exista.
        /// </summary>
        public DateTime? DataDeEncerramento { get; set; } = null;
        
        /// <summary>
        /// Indica se o professor está ativo. Valor padrão: true.
        /// </summary>
        public bool Ativo { get; set; } = true;
    }
}