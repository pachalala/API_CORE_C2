using System;
using System.Collections.Generic;

namespace RES_API.Models;

public partial class IngredientesPlato
{
    public int? IdPlato { get; set; }

    public int? IdIngrediente { get; set; }

    public int? Gramos { get; set; }

    public int Id { get; set; }
}
