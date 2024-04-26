using System;
using System.Collections.Generic;

namespace JobSearchApplication.Models;

public partial class Application
{
    public int ApplicationId { get; set; }

    public int JobPostId { get; set; }

    public byte[]? Resume { get; set; }

    public byte[]? CoverLetter { get; set; }

    public DateTime ApplicationDate { get; set; }

    public string? Status { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    public virtual JobPost JobPost { get; set; } = null!;

    public virtual UserCredential User { get; set; } = null!;
}
