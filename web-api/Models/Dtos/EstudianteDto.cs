namespace universidad.Models.Dtos
{
    public class EstudianteDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string Email { get; set; } = null!;
    }
}
