using System;
using System.Collections.Generic;

namespace LibraryAuthentication.Models;

public partial class Detailuser
{
    public int IdDetailUsers { get; set; }

    public string? CodeDetailUsers { get; set; }

    public string FullName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Description { get; set; }

    public int? Sex { get; set; }

    public string? Address { get; set; }

    public int IdImage { get; set; }

    public int IdUsers { get; set; }
}
