using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.ProfessorDTOs
{
    public class EditMaterialDTO
    {
        public int MaterialId { get; set; } // ID of the material to update
        public string MaterialName { get; set; }
        public string MaterialDescription { get; set; }
        public string URL { get; set; }
    }
}
