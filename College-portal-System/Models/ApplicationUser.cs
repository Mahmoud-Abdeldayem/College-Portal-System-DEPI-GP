using System;
using System.Collections.Generic;

namespace College_portal_System.Models;

public partial class ApplicationUser
{
    public string NationalId { get; set; } = null!;

    public string RecoveryEmail { get; set; } = null!;

    public string? Address { get; set; }

    public bool? Gender { get; set; }

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public byte[]? Picture { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<PasswordResetTicket> PasswordResetTickets { get; set; } = new List<PasswordResetTicket>();

    public virtual Professor? Professor { get; set; }

    public virtual Student? Student { get; set; }

    public virtual ICollection<TeachingAssistant> TeachingAssistantAssistingProfessors { get; set; } = new List<TeachingAssistant>();

    public virtual TeachingAssistant? TeachingAssistantTa { get; set; }

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
