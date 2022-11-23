using System;
using System.Collections.Generic;

namespace BlazorCW.Server.Model;

public partial class Client
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string Lastneme { get; set; } = null!;

    public DateTime? BornDate { get; set; }

    public string? Sex { get; set; }

    public string? Passport { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<ClientAdress> ClientAdresses { get; } = new List<ClientAdress>();

    public virtual ICollection<Sell> Sells { get; } = new List<Sell>();
}
