using System;
using System.Collections.Generic;

namespace BlazorCW.Server.Model;

public partial class Subscriber
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string Lastname { get; set; } = null!;
}
