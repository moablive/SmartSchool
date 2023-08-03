using SmartSchool.API.Models;
using System.Collections.Generic;
using System;

namespace SmartSchool.API.Dtos
{
    public class ProfessorDto
    {
        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public int Idade { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public Boolean Ativo { get; set; } = true;
    }
}
