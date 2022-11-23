using System;
using System.Collections.Generic;

namespace BlazorCW.Server.Model;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Lastname { get; set; }

    public string? Position { get; set; }

    public string Type { get; set; } = null!;

    public decimal? Salary { get; set; }

    public int? CountOfCells { get; set; }

    public virtual ICollection<Sell> Sells { get; } = new List<Sell>();
}
