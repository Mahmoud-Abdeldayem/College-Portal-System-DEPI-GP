using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IStudentRepo
    {
        List<Student> GetAll();
        Student GetById(string id);
        List<Student> Get(Expression<Func<Student, bool>> criteria);
        void DeleteById(int id);
        void Delete(Student student);
        public void Update(string id,ApplicationUser user, IFormFile? pictureFile);
        void Insert(Student student);
        Department GetDepartmentById(int id);
        List<Department> GetAllDepts();
        void UpdateDepartment(string id,int departmentId);
        void ChangePass(string id,string newPass);
        
        
    }
}
