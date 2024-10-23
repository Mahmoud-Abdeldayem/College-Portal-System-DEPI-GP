using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities;
[Index(nameof(Email), IsUnique = true)]
[Index(nameof(UserName), IsUnique = true)]
public class ApplicationUser : IdentityUser
{
    public string NationalId { get; set; } = null!;    

    public string? Address { get; set; }

    [Required,MaxLength(20)]
    public string Gender { get; set; } = null!;          

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    public byte[]? Picture { get; set; }    

    public virtual ICollection<Test> Tests { get; set; } = [];


    #region Relations
    public virtual Professor? Professor { get; set; }
    public virtual Student? Student { get; set; }
    public virtual TeachingAssistant? TeachingAssistantTa { get; set; }

    public virtual ICollection<Notification> NotificationSentByNavigations { get; set; } = [];

    public virtual ICollection<Notification> NotificationSentToNavigations { get; set; } = [];

    public virtual ICollection<PasswordResetTicket> PasswordResetTickets { get; set; } = [];

    public virtual ICollection<TeachingAssistant> TeachingAssistantAssistingProfessors { get; set; } = [];
    #endregion
}
