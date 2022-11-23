using System;
using System.Collections.Generic;

namespace BlazorCW.Server.Model;

public partial class Service
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Price { get; set; }

    public string? Description { get; set; }

    public byte[]? IsArchive { get; set; }

    public virtual ICollection<Sell> Sells { get; } = new List<Sell>();
}
