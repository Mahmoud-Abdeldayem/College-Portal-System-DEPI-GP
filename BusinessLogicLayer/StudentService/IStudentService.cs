using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.StudentService
{
    public interface IStudentService
    {
        public UserViewDTO GetUserById(string id);
        public ProfileDTO GetProfileById(string id);
        public StudentTranscriptDTO GetStudentTranscriptById(string id);
        public RegisterDeptDTO GetDepts(string id);
        public void RegisterDepartment(string id, RegisterDeptDTO deptDTO);
        public void UpdateUser(string id, UserViewDTO user, IFormFile? pictureFile);
        public void ChangePass(string id, ChangePassDTO pass);
        public List<AvailableCoursesDTO> GetAvailableCourses(string id);
        
    }
}
