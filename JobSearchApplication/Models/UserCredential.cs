using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobSearchApplication.Models;

public partial class UserCredential
{
    public int UserId { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    [Required]
    public int Age { get; set; }
    [Required]
    public string Gender { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual ICollection<Connect> ConnectReceivers { get; set; } = new List<Connect>();

    public virtual ICollection<Connect> ConnectSenders { get; set; } = new List<Connect>();

    public virtual ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();

    public virtual Role Role { get; set; } = null!;
}
