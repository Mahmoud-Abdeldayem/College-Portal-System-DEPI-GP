using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class DeptsDTO
    {
        public int DepartmentId { get; set; }

        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;
    }
}
