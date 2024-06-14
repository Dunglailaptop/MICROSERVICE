using System;
using System.Collections.Generic;

namespace LibraryAuthentication.Models;

public partial class User
{
    public int IdUsers { get; set; }

    public string CodeUsers { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool? Status { get; set; }

    public DateTime DateCreate { get; set; }

    public DateTime DateUpdate { get; set; }

    public int IdRole { get; set; }
}
