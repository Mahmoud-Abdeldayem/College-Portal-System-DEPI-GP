using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class TeachingAssistant
{
    public string Taid { get; set; } = null!;

    public string AcademicDegree { get; set; } = null!;

    public string University { get; set; } = null!;

    public string Faculty { get; set; } = null!;

    public int? DepartmentId { get; set; }

    #region Relations
    public virtual ApplicationUser? AssistingProfessor { get; set; }
    public string? AssistingProfessorId { get; set; }
    public virtual ICollection<CourseTeaching> CourseTeachings { get; set; } = [];
    public virtual Department? Department { get; set; }
    public virtual ApplicationUser Ta { get; set; } = null!;
    public virtual ICollection<Task> Tasks { get; set; } = [];

    #endregion
}
