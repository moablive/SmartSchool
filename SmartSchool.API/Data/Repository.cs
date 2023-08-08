using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Helpers;

namespace SmartSchool.API.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;
        public Repository(SmartContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges() { return (_context.SaveChanges() > 0); }

        //Aluno Metodos
        #region Aluno Metodos
        public Aluno[] GetAllAlunos(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);
            return query.ToArray();
        }

        // Metodo Async | ToArrayAsync
        public async Task<PageList<Aluno>> GetAllAlunosAsync(
            PageParams pageParams,
            bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            //Filtro por NOME || SOBRENOME
            if (!string.IsNullOrEmpty(pageParams.Nome))
            {
                query = query.Where(
                    aluno => aluno.Nome.ToUpper()
                        .Contains(pageParams.Nome.ToUpper()) || 
                    aluno.Sobrenome.ToUpper()
                        .Contains(pageParams.Nome.ToUpper()));
            }

            //Filtro de matricula
            if (pageParams.Matricula > 0)
            {
                query = query.Where(
                    aluno => aluno.Matricula == pageParams.Matricula);
            }

            //Filtro de ativo
            if (pageParams.Ativo != null)
            {
                query = query.Where(aluno => aluno.Ativo == (pageParams.Ativo != 0));
            }

            return await PageList<Aluno>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public Aluno[] GetAllAlunosByDisciplinaId(int diciplinaID, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                .OrderBy(a => a.Id)
                .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == diciplinaID));

            return query.ToArray();
        }

        public Aluno GetAlunoById(int alunoId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                .OrderBy(a => a.Id)
                .Where(aluno => aluno.Id == alunoId);

            return query.FirstOrDefault();
        }
        #endregion

        //Professor Metodos
        #region Professor Metodos
        public Professor[] GetAllProfessores(bool includeAlunos)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);
            return query.ToArray();
        }

        public Professor[] GetAllProfessoresByDisciplinaId(int diciplinaID, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking()
                .OrderBy(aluno => aluno.Id)
                .Where(aluno => aluno.Disciplinas.Any(
                    d => d.AlunosDisciplinas.Any(ad => ad.DisciplinaId == diciplinaID)));

            return query.ToArray();
        }

        public Professor GetProfessorById(int professorId, bool includeProfessor = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeProfessor)
            {
                query = query.Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking()
                .OrderBy(a => a.Id)
                .Where(Professor => Professor.Id == professorId);

            return query.FirstOrDefault();
        }
        #endregion
    }
}
