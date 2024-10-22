using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class ChangePassDTO
    {
        public string CurrentPass { get; set; }
        public string NewPass { get; set; }
        public string ConfrimPass { get; set; }

    }
}
