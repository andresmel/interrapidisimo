using System;
using System.Collections.Generic;

namespace universidad.Models
{
    public partial class Clase
    {
        public int IdClase { get; set; }
        public int? IdEstudiante { get; set; }
        public int? IdMateriasProfesores { get; set; }
    }
}
