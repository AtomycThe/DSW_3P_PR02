using DSW_3P_PR02.Models;
using DSW_3P_PR02.Repositories;

namespace DSW_3P_PR02.Services;

public class EventoService : IEventoService
{
    private readonly IEventoRepository _repository;

    public EventoService(IEventoRepository repository)
    {
        _repository = repository;
    }

    private static void Validar(Evento evento)
    {
        if(string.IsNullOrWhiteSpace(evento.Nombre))
            throw new ArgumentException("Nombre obligatorio");

    }

    public List<Evento> ObtenerTodas()
    {
        return _repository.ObtenerTodas();
    }

    public Evento? ObtenerPorId(int id)
    {
        return _repository.ObtenerPorId(id);
    }

    public Evento Agregar(Evento nueva)
    {
        Validar(nueva);
        return _repository.Agregar(nueva);
    }

    public bool Actualizar(int id, Evento actulizada)
    {
        Validar(actulizada);
        return _repository.Actualizar(id, actulizada);
    }

    public bool Eliminar(int id)
    {
        var evento = _repository.ObtenerPorId(id);

        if(evento == null)
            return false;

        return _repository.Eliminar(id);
    }
}
