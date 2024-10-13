using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class PasswordResetTicket
{
    public int TicketId { get; set; }

    public string? StudentId { get; set; }

    public DateTime RequestDate { get; set; }

    public DateTime? ResetDate { get; set; }

    public bool State { get; set; }

    public string? AdminId { get; set; }

    public virtual ApplicationUser? Admin { get; set; }

    public virtual Student? Student { get; set; }
}
