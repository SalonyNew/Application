using System;
using System.Collections.Generic;

namespace JobSearchApplication.Models;

public partial class Connect
{
    public int ConnectionId { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public string? Status { get; set; }

    public DateTime ConnectionDate { get; set; }

    public virtual ICollection<ChatSection> ChatSections { get; set; } = new List<ChatSection>();

    public virtual UserCredential Receiver { get; set; } = null!;

    public virtual UserCredential Sender { get; set; } = null!;
}
