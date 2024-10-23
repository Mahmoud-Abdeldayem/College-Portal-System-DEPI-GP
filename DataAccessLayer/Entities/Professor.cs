namespace DataAccessLayer.Entities;

public partial class Professor
{
    public string ProfessorId { get; set; } = null!;

    public string PhDat { get; set; } = null!;

    public int EnterYear { get; set; }

    public string? OfficeLocation { get; set; }

    public string DocUni { get; set; } = null!;

    public string Title { get; set; } = null!;

    #region Relations    
    public virtual Department? Department { get; set; }
    public int? DepartmentId { get; set; }
    public virtual ICollection<CourseTeaching> CourseTeachings { get; set; } = [];
    public virtual ICollection<Department> Departments { get; set; } = [];
    public virtual ICollection<Timetable> Timetables { get; set; } = [];
    public virtual ApplicationUser ProfessorNavigation { get; set; } = null!;
    #endregion
}
