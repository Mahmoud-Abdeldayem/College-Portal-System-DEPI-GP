using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class CourseEnrollment
{
    public int EnrollmentId { get; set; }

    public string? StudentId { get; set; }

    public int? CourseId { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public decimal ClassWork { get; set; }

    public decimal FinalGrade { get; set; }

    public bool? State { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Student? Student { get; set; }
}
