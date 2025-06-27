using Microsoft.EntityFrameworkCore.Metadata;

namespace universidad.Models.Dtos
{
    public class claseMaDto
    {
        public int id_clase { get; set; }
        public int id_estudiante { get; set; }
        public string ?estudiante { get; set; } = null!;
        public string ?materia { get; set; } = null!;
        public string ?profesor { get; set; } = null!;   
    }
}
