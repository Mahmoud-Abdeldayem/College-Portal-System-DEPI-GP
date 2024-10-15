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
    public class TARepository : ITARepository 
    {
        private readonly AppDbContext _context;
        public TARepository(AppDbContext context)
        {
            _context = context;
        }
        public TeachingAssistant Delete(TeachingAssistant Entity)
        {
            throw new NotImplementedException();
        }

        public TeachingAssistant DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeachingAssistant> Get(Expression<Func<TeachingAssistant, bool>> criteria)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeachingAssistant> GetAll()
        {
            throw new NotImplementedException();
        }

        public TeachingAssistant GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseTeaching> GetCourseTeachings(string teachingAssistantId)
        {
            var teachingAssistantCourses = _context.CourseTeachings.Where(ta => ta.Taid == teachingAssistantId)
                                                             .Include(c => c.Course)
                                                             .Include(c => c.Professor)
                                                             .ThenInclude(p => p.ProfessorNavigation);
            return teachingAssistantCourses;
        }

        public TeachingAssistant Insert(TeachingAssistant entity)
        {
            throw new NotImplementedException();
        }

        public TeachingAssistant Update(TeachingAssistant entity)
        {
            throw new NotImplementedException();
        }
    }
}
