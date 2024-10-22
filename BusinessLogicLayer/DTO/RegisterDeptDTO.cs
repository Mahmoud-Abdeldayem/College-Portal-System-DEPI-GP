using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class RegisterDeptDTO
    { 
        public int? StudentDepartment {  get; set; }
        public List<DeptsDTO> Depts { get; set; }=new List<DeptsDTO>();
    }
}
