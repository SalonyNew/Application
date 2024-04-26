using System;
using System.Collections.Generic;

namespace JobSearchApplication.Models;

public partial class Interview
{
    public int InterviewId { get; set; }

    public int ApplicationId { get; set; }

    public DateTime? InterviewDate { get; set; }

    public string? Status { get; set; }

    public string? Notes { get; set; }

    public virtual Application Application { get; set; } = null!;
}
