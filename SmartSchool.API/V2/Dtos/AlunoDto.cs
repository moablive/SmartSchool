using SmartSchool.API.Models;
using System.Collections.Generic;
using System;

namespace SmartSchool.API.V2.Dtos
{
    public class AlunoDto
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public int Idade { get; set; }
        public DateTime DataIni { get; set; }
        public Boolean Ativo { get; set; }
    }
}
