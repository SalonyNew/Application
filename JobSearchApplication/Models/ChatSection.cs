using System;
using System.Collections.Generic;

namespace JobSearchApplication.Models;

public partial class ChatSection
{
    public int ChatId { get; set; }

    public int ConnectionId { get; set; }

    public string? Content { get; set; }

    public DateTime TimeStamp { get; set; }

    public string? Status { get; set; }

    public virtual Connect Connection { get; set; } = null!;
}
