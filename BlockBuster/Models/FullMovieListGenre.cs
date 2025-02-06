using System;
using System.Collections.Generic;

namespace BlockBuster.Models;

public partial class FullMovieListGenre
{
    public string Title { get; set; } = null!;

    public int ReleaseYear { get; set; }

    public string LastName { get; set; } = null!;

    public string GenreDescr { get; set; } = null!;
}
