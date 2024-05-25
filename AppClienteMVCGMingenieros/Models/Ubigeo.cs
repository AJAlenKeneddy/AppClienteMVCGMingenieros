using System;
using System.Collections.Generic;

namespace AppClienteMVCGMingenieros.Models;

public partial class Ubigeo
{
    public string Id { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? ProvinceId { get; set; }

    public string? DepartmentId { get; set; }
}
