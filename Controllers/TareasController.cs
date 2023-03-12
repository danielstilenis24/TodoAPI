using Microsoft.AspNetCore.Mvc;

namespace TodoAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TareasController : ControllerBase
{
    private List<Tarea> tareas = new List<Tarea>
    {
        new Tarea { Id = 1, Titulo = "Tarea 1", FechaCreacion = DateTime.Now.AddDays(-1), Completado = false },
        new Tarea { Id = 2, Titulo = "Tarea 2", FechaCreacion = DateTime.Now.AddDays(-1), Completado = false },
    };

    [HttpGet]
    public IEnumerable<Tarea> GetTareas()
    {
        return tareas;
    }

    [HttpGet("{id}")]
    public IActionResult ObtenerTareaPorId(int id)
    {
        var tarea = tareas.FirstOrDefault(t => t.Id == id);

        if (tarea == null)
        {
            return NotFound();
        }

        return Ok(tarea);
    }


    [HttpPost]
    public IActionResult AgregarTarea(Tarea tareaInsertada)
    {
        tareas.Add(tareaInsertada);

        return Ok(tareaInsertada);
    }

    [HttpPut("{id}")]
    public IActionResult ActualizarTarea(int id, Tarea tareaActualizada)
    {
        var tareaExistente = tareas.FirstOrDefault(t => t.Id == id);

        if (tareaExistente == null)
        {
            return NotFound();
        }

        tareaExistente.Completado = tareaActualizada.Completado;

        return Ok(tareaExistente);
    }

}