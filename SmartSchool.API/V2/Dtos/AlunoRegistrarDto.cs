using SmartSchool.API.Models;
using System.Collections.Generic;
using System;

namespace SmartSchool.API.V2.Dtos
{
    /// <summary>
    /// Este é o DTO de Aluno Para Registrar. 
    /// </summary>
    public class AlunoRegistrarDto
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public Boolean Ativo { get; set; } = true;
    }
}
