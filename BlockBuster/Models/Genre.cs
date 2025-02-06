using System;
using System.Collections.Generic;

namespace BlockBuster.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string GenreDescr { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
