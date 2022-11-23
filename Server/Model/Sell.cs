using System;
using System.Collections.Generic;

namespace BlazorCW.Server.Model;

public partial class Sell
{
    public int Id { get; set; }

    public int EmployeesId { get; set; }

    public int ServiceId { get; set; }

    public int ClientId { get; set; }

    public int ClientAdressId { get; set; }

    public byte[]? IsPayed { get; set; }

    public byte[]? IsConnected { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ClientAdress ClientAdress { get; set; } = null!;

    public virtual Employee Employees { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
