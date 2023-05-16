using System;
using System.Collections.Generic;

namespace RES_API.Models;

public partial class Plato
{
    public int Id { get; set; }

    public int Integrantes { get; set; }

    public string Nombre { get; set; } = null!;
}
