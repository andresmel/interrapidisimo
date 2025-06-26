using System;
using System.Collections.Generic;

namespace universidad.Models
{
    public partial class Estudiante
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
