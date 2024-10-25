using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IMaterialRepository
    {

        public IEnumerable<Material> GetAllMaterials();

        public Material GetMaterialsByCourseId(int id);

        public void AddMaterial(Material material);

        public void UpdateMaterial(Material material);

        public void DeleteMaterial(int id);
    }
}
