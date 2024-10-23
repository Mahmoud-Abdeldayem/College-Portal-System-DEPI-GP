using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public TeachingAssistant Delete(TeachingAssistant entity)
        {
            var ta = _context.TeachingAssistants.Find(entity.Taid);
            if (ta != null)
            {
                _context.TeachingAssistants.Remove(ta);
                _context.SaveChanges();
            }
            return ta;
        }

        public TeachingAssistant DeleteById(int id)
        {
            var ta = _context.TeachingAssistants.Find(id);
            if (ta != null)
            {
                _context.TeachingAssistants.Remove(ta);
                _context.SaveChanges();
            }
            return ta;
        }

        public IEnumerable<TeachingAssistant> Get(Expression<Func<TeachingAssistant, bool>> criteria)
        {
            return _context.TeachingAssistants.Where(criteria).ToList();
        }

        public IEnumerable<TeachingAssistant> GetAll()
        {
            return _context.TeachingAssistants.Include(ta => ta.AssistingProfessor).ToList();
        }

        public List<Entities.Task> GetAllTATasks(string taId)
        {
            var tasks = _context.Tasks.Include(t => t.Course)
                                      .Where(t => t.AssignedByTaid == taId)
                                      .ToList();
            return tasks;
        }

        // Get Teaching Assistant by Id
        public TeachingAssistant GetById(int id)
        {
            return _context.TeachingAssistants.Include(ta => ta.AssistingProfessor)
                                              .FirstOrDefault(ta => ta.Taid == id.ToString());
        }

        public TeachingAssistant GetById(string id)
        {
            throw new NotImplementedException();
        }

        // Get all Course Teachings assigned to a specific Teaching Assistant
        public IEnumerable<CourseTeaching> GetCourseTeachings(string teachingAssistantId)
        {
            return _context.CourseTeachings.Include(ct => ct.Course)
                                           .Include(ct => ct.Professor)
                                           .ThenInclude(p => p.ProfessorNavigation)
                                           .Where(ct => ct.Taid == teachingAssistantId)
                                           .ToList();
        }

        // Get general data of a Teaching Assistant
        public ApplicationUser GetTAGeneralData(string id)
        {
            return _context.TeachingAssistants.Include(ta => ta.Ta)
                                              .Where(ta => ta.Taid == id)
                                              .Select(ta => ta.Ta)
                                              .FirstOrDefault();
        }

        // Insert a new Teaching Assistant
        public TeachingAssistant Insert(TeachingAssistant entity)
        {
            _context.TeachingAssistants.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        // Update an existing Teaching Assistant
        public TeachingAssistant Update(TeachingAssistant entity)
        {
            var ta = _context.TeachingAssistants.FirstOrDefault(a => a.Taid == entity.Taid);
            if (ta != null)
            {
                _context.Entry(ta).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }
            return ta;
        }

        public ApplicationUser UpdateProfileInfo(ApplicationUser TA)
        {
            // These Data musn't be updated from the BLL
            var oldTAData = _context.ApplicationUsers.Find(TA.NationalId);
            TA.FirstName = oldTAData.FirstName;
            TA.LastName = oldTAData.LastName;
            TA.Gender = oldTAData.Gender;
            //TA.Role = oldTAData.Role;
            
            _context.ApplicationUsers.Update(TA);
            return oldTAData;
        }

        // Update Profile Info of ApplicationUser (for future implementation)
        //public ApplicationUser UpdateProfileInfo(ApplicationUser user)
        //{
        //    var existingUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);
        //    if (existingUser != null)
        //    {
        //        _context.Entry(existingUser).CurrentValues.SetValues(user);
        //        _context.SaveChanges();
        //    }
        //    return existingUser;
        //}
    }
}
