﻿using System;
using System.Collections.Generic;

namespace JobSearchApplication.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UserCredential> UserCredentials { get; set; } = new List<UserCredential>();
}
