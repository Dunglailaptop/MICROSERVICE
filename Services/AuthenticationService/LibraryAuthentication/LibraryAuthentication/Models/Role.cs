using System;
using System.Collections.Generic;

namespace LibraryAuthentication.Models;

public partial class Role
{
    public int IdRole { get; set; }

    public string? CodeRole { get; set; }

    public string? NameRole { get; set; }

    public bool? Status { get; set; }

    public DateTime DateCreate { get; set; }

    public DateTime DateUpdate { get; set; }
}
