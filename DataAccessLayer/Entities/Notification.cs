using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class Notification
{
    public int NotificationId { get; set; }

    public string Message { get; set; } = null!;

    public string? SentBy { get; set; }

    public string? SentTo { get; set; }

    public bool State { get; set; }

    public virtual ApplicationUser? SentByNavigation { get; set; }

    public virtual ApplicationUser? SentToNavigation { get; set; }
}
