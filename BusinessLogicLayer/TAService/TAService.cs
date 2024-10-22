using BusinessLogicLayer.DTOs.TADTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.TAService
{
    public class TAService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TAService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public List<TACoursesDTO> GetTACourses(string teachingAssistantId)
        { 
            var courses = _unitOfWork.TAs.GetCourseTeachings(teachingAssistantId)
                          .Select(ct => new TACoursesDTO{CourseID = ct.CourseId ,CourseName = ct.Course.Name,ProfessorName =
                          (ct.Professor.ProfessorNavigation.FirstName + " " + ct.Professor.ProfessorNavigation.LastName)
                          });
            return courses.ToList();
        }

        public TADataDTO GetTAGeneralInfo(string teachingAssistantId)
        {
            var taData = _unitOfWork.TAs.GetTAGeneralData(teachingAssistantId);
            if (taData != null)
            {
                return new TADataDTO()
                {
                    NationalID = taData.NationalId,
                    FName = taData.FirstName,
                    LName = taData.LastName,
                    Address = taData.Address,
                    //Email = taData.RecoveryEmail,
                    //Image = taData.Picture,
                    //Password = taData.Password
                };
            }
            return null;
        }

        public void UpdateTAProfile(TADataDTO taData)
        {
            var dataToUpdate = new ApplicationUser()
            {
                NationalId = taData.NationalID ,
                Address = taData.Address ,
                //RecoveryEmail = taData.Email ,
                //Password = taData.Password ,
                //Picture = taData.Image ,
            };
            var ta = _unitOfWork.TAs.UpdateProfileInfo(dataToUpdate);
            _unitOfWork.Commit();
        }

        public List<EditTaskDTO> GetTATasks(string taId)
        {
            var tasks = _unitOfWork.TAs.GetAllTATasks(taId).Select(
                    t => new EditTaskDTO()
                    {
                        TaskId = t.TaskId,
                        CourseId = t.CourseId,
                        Deadline = t.Deadline,
                        Type = t.Type,
                        AssignedByTaid = t.AssignedByTaid,
                        Grade = t.Grade,
                        TaskLink = t.TaskLink,
                        Content = t.Content,
                        CourseName = t.Course.Name
                    }
                ).ToList();
            return tasks;
        }

        public void CreateTask(CreateTaskDTO task)
        {
            var newTask = new DataAccessLayer.Entities.Task()
            {
                CourseId = task.CourseId,
                Grade = task.Grade,
                Deadline = task.Deadline,
                Content = task.Content,
                Type = task.Type,
                AssignedByTaid = "30403468745632",
                TaskLink = task.TaskLink
            };
            var insertedTask = _unitOfWork.Tasks.Insert(newTask);
            _unitOfWork.Commit();
        }
    }
}
