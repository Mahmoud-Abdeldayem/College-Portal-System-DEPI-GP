using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class BaseModel
    {
        public DateTime CreatedOn { get; set; }
        public string? CreatedById { get; set; }
        public bool IsDeleted { get; set; }
    }
}
