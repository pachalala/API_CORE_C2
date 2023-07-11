using System;
using System.Collections.Generic;

namespace RES_API.Models;

public partial class UsuUsuario
{
    public string UsuLogin { get; set; } = null!;

    public string UsuRut { get; set; } = null!;

    public int? UsuIdrol { get; set; }

    public string? UsuNombre { get; set; }

    public string? UsuPasswd { get; set; }

    public string? UsuEnable { get; set; }

    public int? UsuRegion { get; set; }

    public string? UsuUltimoacceso { get; set; }

    public DateTime? UsuCambioclave { get; set; }

    public int? UsuNuevo { get; set; }

    public virtual RolRole? UsuIdrolNavigation { get; set; }
}
