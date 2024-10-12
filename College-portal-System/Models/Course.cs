using System;
using System.Collections.Generic;

namespace College_portal_System.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public int Hours { get; set; }

    public int? PrerequisiteCourseId { get; set; }

    public bool Semseter { get; set; }

    public int? DepartmentId { get; set; }

    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();

    public virtual ICollection<CourseTeaching> CourseTeachings { get; set; } = new List<CourseTeaching>();

    public virtual Department? Department { get; set; }

    public virtual ICollection<Course> InversePrerequisiteCourse { get; set; } = new List<Course>();

    public virtual Course? PrerequisiteCourse { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();

    public virtual ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
}
