using System;
using System.Collections.Generic;

namespace College_portal_System.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public string Message { get; set; } = null!;

    public string? SentByAdminId { get; set; }

    public virtual ApplicationUser? SentByAdmin { get; set; }
}
