using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace DataAccessLayer.Repositories
{
    public class StudentRepo : IStudentRepo
    {
        private readonly AppDbContext _context;
        public StudentRepo(AppDbContext context)
        {
            _context = context;
        }
        public void Delete(Student student)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> Get(Expression<Func<Student, bool>> criteria)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll()
        {
            var students=_context.Students.ToList();
            return students;
        }

        public Student GetById(string id)
        {
            var student = _context.Students.FirstOrDefault(x => x.NationalId == id);
            return student;
        }

        public void Insert(Student student)
        {
            throw new NotImplementedException();
        }

        public void Update(string id, ApplicationUser user, IFormFile? pictureFile)
        {
            var existing = _context.ApplicationUsers.FirstOrDefault(x => x.NationalId == id);
            if (existing != null)
            {
                existing.FirstName = user.FirstName;
                existing.LastName = user.LastName;
                existing.RecoveryEmail = user.RecoveryEmail;
                existing.Address = user.Address;
            }
            if (pictureFile != null && pictureFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    pictureFile.CopyTo(memoryStream);
                    existing.Picture = memoryStream.ToArray();
                }
            }
            _context.Entry(existing).State = EntityState.Modified;
        }



        public Department GetDepartmentById(int id)
        {
            return _context.Departments.Find(id);
        }
        public List<Department> GetAllDepts()
        {
            var depts=_context.Departments.ToList();
            return depts;
        }
        public void UpdateDepartment(string id,int departmentId)
        {
            var student=GetById(id);
            student.DepartmentId = departmentId;
        }

        public void ChangePass(string id, string newPass)
        {
            var existing = _context.ApplicationUsers.FirstOrDefault(x => x.NationalId == id);
            existing.Password = newPass;

        }
        
    }

}
