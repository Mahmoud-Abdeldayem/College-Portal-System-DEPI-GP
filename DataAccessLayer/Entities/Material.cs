using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Material : BaseModel
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; } = null!;
        [Required, MaxLength(350)]
        public string Description { get; set; } = null!;

        [DataType(DataType.Url)]
        public string Link { get; set; } = null!;

        #region Relations
        public Course? Course { get; set; }

        [ForeignKey("CourseId")]       
        public int CourseId { get; set; }
        #endregion
    }
}
