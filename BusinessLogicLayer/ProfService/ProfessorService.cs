using DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ProfService
{
    using DataAccessLayer.Interfaces;
    using DataAccessLayer.Entities;
    using System.Collections.Generic;
    using System.Linq;
    using global::BusinessLogicLayer.DTOs.ProfessorDTOs;

    namespace BusinessLogicLayer.MaterialService
    {
        public class ProfessorService
        {
            private readonly IUnitOfWork _unitOfWork;

            public ProfessorService(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            // Method to get all materials for a specific course
            public List<MaterialDTO> GetCourseMaterials(int courseId)
            {
                var materials = _unitOfWork.MaterialRepo.GetAllMaterials()
                    .Select(m => new MaterialDTO
                    {
                        MaterialName = m.Name,
                        MaterialDescription = m.Description,
                        URL = m.Link,
                        Course = m.Course.Name
                    });
                return materials.ToList();
            }

            public MaterialDTO GetMaterialInfo(int materialId)
            {
                var material = _unitOfWork.MaterialRepo.GetMaterialsByCourseId(materialId);
                if (material != null)
                {
                    return new MaterialDTO
                    {
                        MaterialName = material.Name,
                        MaterialDescription = material.Description,
                        URL = material.Link,
                        Course = material.Course.Name
                    };
                }
                return null;
            }

            public void UpdateMaterial(EditMaterialDTO editMaterialDto)
            {
                var materialToUpdate = _unitOfWork.MaterialRepo.GetMaterialsByCourseId(editMaterialDto.MaterialId);
                if (materialToUpdate != null)
                {
                    materialToUpdate.Name = editMaterialDto.MaterialName;
                    materialToUpdate.Description = editMaterialDto.MaterialDescription;
                    materialToUpdate.Link = editMaterialDto.URL;
                    _unitOfWork.MaterialRepo.UpdateMaterial(materialToUpdate);
                    _unitOfWork.Commit();
                }
            }

            public void CreateMaterial(MaterialDTO materialDto)
            {
                var newMaterial = new Material
                {
                    Name = materialDto.MaterialName,
                    Description = materialDto.MaterialDescription,
                    Link = materialDto.URL,
                    CourseId = materialDto.CourseId 
                };
                _unitOfWork.MaterialRepo.AddMaterial(newMaterial);
                _unitOfWork.Commit(); 
            }
        }
    }

}
