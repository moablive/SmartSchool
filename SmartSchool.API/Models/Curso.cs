using System.Collections;
using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class Curso
    {
        public Curso(int id, string nome)
        {
            this.id = id;
            this.Nome = nome;
        }

        public int id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }

}
