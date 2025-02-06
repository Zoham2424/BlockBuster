using System;
using System.Collections.Generic;

namespace BlockBuster.Models;

public partial class Director
{
    public int DirectorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
