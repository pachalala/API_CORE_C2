using System;
using System.Collections.Generic;

namespace RES_API.Models;

public partial class RolRole
{
    public int RolIdrol { get; set; }

    public string? RolNombrerol { get; set; }

    public virtual ICollection<UsuUsuario> UsuUsuarios { get; set; } = new List<UsuUsuario>();
}
