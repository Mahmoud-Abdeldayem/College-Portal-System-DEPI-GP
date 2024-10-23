using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ProfessorsRepoitory 
    {
        private readonly AppDbContext _context;

        public ProfessorsRepoitory(AppDbContext appDbContext)
        {
            _context = appDbContext;   
        }
        public Professor Delete(Professor professor)
        {
            _context.Remove(professor);
            return professor;
        }

        public Professor DeleteById(string id)
        {
            var prof = _context.Professors.Where(p => p.ProfessorId == id).FirstOrDefault();
            if (prof != null)
            {
                _context.Remove(prof);
                return prof;
            }
            else
            {
                throw new Exception("There is no professor with this id to delete");
            }
        }

        public IEnumerable<Professor> Get(Expression<Func<Professor, bool>> criteria)
        {
            var professors = _context.Professors.Include(p => p.ProfessorNavigation).Where(criteria);
            return professors;
        }

        public IEnumerable<Professor> GetAll()
        {
            var professors = _context.Professors.Include(p => p.ProfessorNavigation);
            return professors;
        }

        public Professor GetById(string id)
        {
            var prof = _context.Professors.Where(p => p.ProfessorId == id).FirstOrDefault();
            if (prof != null)
            {
                return prof;
            }
            else
            {
                throw new Exception("There is no professor with this id");
            }
        }

        public Professor Insert(Professor professor)
        {
            _context.Professors.Add(professor);
            return professor;
        }

        public Professor Update(Professor professor)
        {
            _context.Update(professor);
            return professor;
        }
    }
}
