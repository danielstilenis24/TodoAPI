namespace TodoAPI;

public class Tarea
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public DateTime FechaCreacion { get; set; }
    public bool Completado { get; set; }
}
