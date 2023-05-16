using System;
using System.Collections.Generic;

namespace RES_API.Models;

public partial class Ingrediente
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? Cantidad { get; set; }

    public sbyte? Chek { get; set; }
}
