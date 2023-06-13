using System;
using System.Collections.Generic;

namespace RES_API.Models;

public partial class Region
{
    public short CodRegion { get; set; }

    public string? Nombre { get; set; }

    public string? ComprobantePos { get; set; }

    public string? Fonos { get; set; }
}
