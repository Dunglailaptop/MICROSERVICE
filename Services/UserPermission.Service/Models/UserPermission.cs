using System;
using System.Collections.Generic;

namespace UserPermission.Service.Models;

public partial class UserPermission
{
    public int IdUserPermission { get; set; }

    public string CodeUserPermission { get; set; } = null!;

    public string NameRole { get; set; } = null!;

    public bool Status { get; set; }

    public DateTime DateCreate { get; set; }

    public DateTime DateUpdate { get; set; }
}
