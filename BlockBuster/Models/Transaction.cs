using System;
using System.Collections.Generic;

namespace BlockBuster.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int MovieId { get; set; }

    public int CustomerId { get; set; }

    public DateOnly CheckedOutDate { get; set; }

    public DateOnly DueDate { get; set; }

    public string CheckedIn { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}
