using System;
using System.Collections.Generic;

namespace BlazorCW.Server.Model;

public partial class ClientAdress
{
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public string? HouseNumber { get; set; }

    public string ApartmentNumber { get; set; } = null!;

    public virtual Client? Client { get; set; }

    public virtual ICollection<Sell> Sells { get; } = new List<Sell>();
}
