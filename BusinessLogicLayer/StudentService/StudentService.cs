using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.StudentService
{
    public class StudentService : IStudentService
    {   
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public ProfileDTO GetProfileById(string id)
        {
            var student=_unitOfWork.StudentRepo.GetById(id);
            var user=_unitOfWork.ApplicationUserRepo.GetById(id);
            if (student.DepartmentId == null)
            {
                return new ProfileDTO
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    RecoveryEmail = user.RecoveryEmail,
                    Address = user.Address,
                    Gender = user.Gender, 
                    Picture = user.Picture,
                    StudentId = student.StudentId,
                    EntryYear = student.EntryYear,
                    GradYear = student.GradYear,
                    CurrentState = student.CurrentState,
                    CollegeState = student.CollegeState,
                    CurrentYear = student.CurrentYear,
                    TotalGpa = student.TotalGpa,
                    HoursTaken = student.HoursTaken,
                    DepartmentId = student.DepartmentId,
                    DepartmentName = null, // Handle potential null
                    NationalId = student.NationalId

                };
            }
            else
            {
                var department=_unitOfWork.StudentRepo.GetDepartmentById((int)student.DepartmentId);
                return new ProfileDTO
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    RecoveryEmail = user.RecoveryEmail,
                    Address = user.Address,
                    Gender = user.Gender, // Assuming false for null values
                    Picture = user.Picture,
                    StudentId = student.StudentId,
                    EntryYear = student.EntryYear,
                    GradYear = student.GradYear,
                    CurrentState = student.CurrentState,
                    CollegeState = student.CollegeState,
                    CurrentYear = student.CurrentYear,
                    TotalGpa = student.TotalGpa,
                    HoursTaken = student.HoursTaken,
                    DepartmentId = student.DepartmentId,
                    DepartmentName =department.Name, // Handle potential null
                    NationalId = student.NationalId
                };
            }

            
        }

        public StudentTranscriptDTO GetStudentTranscriptById(string id)
        {
            var student=GetProfileById(id);
            var courseEnrollment=_unitOfWork.CourseEnrollmentRepo.GetAll();
            var course=_unitOfWork.CourseRepo.GetAll();
            var transcripts= from enrollment in courseEnrollment
                             join courses in course on enrollment.CourseId equals courses.CourseId
                             where enrollment.StudentId==id
                             select new TranscriptDTO
                             {
                                 CourseName = courses.Name,
                                 CourseCode = courses.Code,
                                 Hours = courses.Hours,
                                 FinalGrade = enrollment.FinalGrade
                             };
            if(student.DepartmentId == 0)
            {
                return new StudentTranscriptDTO
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Picture = student.Picture,
                    TotalGpa = student.TotalGpa,
                    HoursTaken = student.HoursTaken,
                    CurrentState = student.CurrentState,
                    CurrentYear = student.CurrentYear,
                    DepartmentName = null,
                    NationalId = student.NationalId,
                    StudentId = student.StudentId,
                    Gender = student.Gender,
                    Transcripts = transcripts.ToList()
                };
            }
            else
            {
            return new StudentTranscriptDTO
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Picture = student.Picture,
                TotalGpa = student.TotalGpa,
                HoursTaken = student.HoursTaken,
                CurrentState = student.CurrentState,
                CurrentYear = student.CurrentYear,
                DepartmentName = student.DepartmentName, 
                NationalId = student.NationalId,
                StudentId = student.StudentId,
                Gender = student.Gender,
                Transcripts = transcripts.ToList()
            };
            }
            
        }

        public UserViewDTO GetUserById(string id)
        {
            var user = _unitOfWork.ApplicationUserRepo.GetById(id);
            return new UserViewDTO
            {
                FirstName=user.FirstName,
                LastName=user.LastName,
                Address=user.Address,
                RecoveryEmail=user.RecoveryEmail,
                NationalId=user.NationalId,
                Gender=user.Gender,
                Password=user.Password,
                Picture=user.Picture,
                Role=user.Role,
            };
        }
        public RegisterDeptDTO GetDepts(string id)
        {
            var departments = _unitOfWork.StudentRepo.GetAllDepts();
            var student = _unitOfWork.StudentRepo.GetById(id);
            var depts = from dept in departments
                        select new DeptsDTO
                        {
                            DepartmentId = dept.DepartmentId,
                            Name = dept.Name,
                            Code = dept.Code
                        };
            return new RegisterDeptDTO
            {
                StudentDepartment=student.DepartmentId,
                Depts=depts.ToList()
            };
        }
        public void RegisterDepartment(string id,RegisterDeptDTO deptDTO)
        {
            _unitOfWork.StudentRepo.UpdateDepartment(id, (int)deptDTO.StudentDepartment);
            _unitOfWork.Commit();
        }
        public void UpdateUser(string id,UserViewDTO user, IFormFile? pictureFile)
        {
            var DataToUpdate = new ApplicationUser
            {
                FirstName = user.FirstName,
                LastName =user.LastName,
                Address = user.Address,
                RecoveryEmail = user.RecoveryEmail,
                Picture=user.Picture,
            };
            _unitOfWork.StudentRepo.Update(id,DataToUpdate,pictureFile);
            _unitOfWork.Commit();

        }

        public void ChangePass(string id, ChangePassDTO pass)
        {
            _unitOfWork.StudentRepo.ChangePass(id,pass.NewPass);
            _unitOfWork.Commit();
        }

        public List<AvailableCoursesDTO> GetAvailableCourses(string id)
        {
            var courses = _unitOfWork.CourseRepo.GetAll();
            var student = _unitOfWork.StudentRepo.GetById(id);
            var takenCourses = _unitOfWork.CourseEnrollmentRepo.GetAll()
                              .Where(enrollment => enrollment.StudentId==id)
                              .Select(enrollment => enrollment.CourseId)
                              .ToList();
            var CurrentDate = DateTime.Now;
            var CurrentYear = CurrentDate.Year;
            var isOctober = CurrentDate.Month == 10;
            var isFebruary = CurrentDate.Month == 2;
            if (isOctober)
            {
                var AvailableCourses = (from course in courses
                                       where course.Semseter == false &&
                                       course.CourseLevel <=student.CurrentYear &&
                                       !takenCourses.Contains(course.CourseId)
                                        select new AvailableCoursesDTO
                                       {
                                           Name = course.Name,
                                           Code = course.Code,
                                       }).ToList();
                return AvailableCourses;
            }else if (isFebruary)
            {
                var AvailableCourses = (from course in courses
                                        where course.Semseter == true &&
                                        course.CourseLevel <= student.CurrentYear &&
                                        !takenCourses.Contains(course.CourseId)
                                        select new AvailableCoursesDTO
                                        {
                                            Name = course.Name,
                                            Code = course.Code,
                                        }).ToList();
                return AvailableCourses;
            }
            else
            {
                return null;
            }
            

        }
    }
}
