using System;
using System.Collections.Generic;

namespace universidad.Models
{
    public partial class MateriasProfesore
    {
        public int Id { get; set; }
        public int? IdProfesor { get; set; }
        public int? IdMateria { get; set; }
    }
}
