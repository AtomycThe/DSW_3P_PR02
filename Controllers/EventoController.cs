using DSW_3P_PR02.Models;
using DSW_3P_PR02.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSW_3P_PR02.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    private readonly IEventoService _service;

    public EventoController(IEventoService service)
    {
        _service = service;
    }

    [HttpGet]
    [EndpointSummary("Obtener todas los eventos")]
    [ProducesResponseType(typeof(List<Evento>), StatusCodes.Status200OK)]
    public IActionResult ObtenerTodas() => Ok(_service.ObtenerTodas());

    [HttpGet("{id:int}")]
    [EndpointSummary("Obtener por id")]
    [ProducesResponseType(typeof(List<Evento>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult ObtenerPorId(int id)
    {
        var evento = _service.ObtenerPorId(id);
        return evento == null ? NotFound() : Ok(evento);
    }

    [HttpPost]
    [EndpointSummary("Agregar mision")]
    [ProducesResponseType(typeof(Evento), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Agregar([FromBody] Evento evento)
    {
        try
        {
            var creado = _service.Agregar(evento);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.Id }, creado); }
        catch(ArgumentException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
    }

    [HttpPut]
    [EndpointSummary("Actualizar mision")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public IActionResult Actualizar(int id, [FromBody] Evento evento)
    {
        try
        {
            return _service.Actualizar(id, evento) ? NoContent() : NotFound();
        }
        catch(ArgumentException ex)
        {
            return BadRequest(new { mesanje = ex.Message });
        }
    }

    [HttpDelete]
    [EndpointSummary("Eliminar evento")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public IActionResult Eliminar(int id)
    {
        try
        {
            return _service.Eliminar(id) ? NoContent() : NotFound();
        }
        catch(ArgumentNullException ex)
        {
            return Conflict(new { mensaje = ex.Message});
        }
    }
}
