using System;
using System.Collections.Generic;

namespace LibraryAuthentication.Models;

public partial class Userpermission
{
    public int IdUserPermssions { get; set; }

    public string? CodeUserPermssions { get; set; }

    public string? NameUserPermissions { get; set; }

    public bool? IsRead { get; set; }

    public bool? IsCreate { get; set; }

    public bool? IsDelete { get; set; }

    public bool? IsEdit { get; set; }

    public int IdRole { get; set; }
}
