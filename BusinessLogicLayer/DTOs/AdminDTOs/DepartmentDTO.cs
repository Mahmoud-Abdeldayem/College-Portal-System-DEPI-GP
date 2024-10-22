using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.AdminDTOs
{
    public class DepartmentDTO
    {
        public int DepartmentId { get; set; }

        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;

        public string? HeadId { get; set; }

    }
}
