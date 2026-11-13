using DSW_3P_PR02.Data;
using DSW_3P_PR02.Models;

namespace DSW_3P_PR02.Repositories;

public class EventoSQLRepository : IEventoRepository
{
    private readonly AppDbContext _context; // Propieda privada empieza con un guion bajo

    public EventoSQLRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Evento> ObtenerTodas()
    {
        return _context.Eventos.ToList();
    }

    public Evento? ObtenerPorId(int id)
    {
        return _context.Eventos.Find(id);
    }

    public Evento Agregar(Evento evento)
    {
        evento.Id = 0; // Asegurarse de que el Id sea 0 para que se genere automáticamente

        _context.Eventos.Add(evento);
        _context.SaveChanges();

        return evento;
    }

    public bool Actualizar(int id, Evento mision)
    {
        var actual = _context.Eventos.Find(id);
        if(actual == null)
            return false;

        actual.Nombre = mision.Nombre;
        actual.Categoria = mision.Categoria;
        actual.Fecha = mision.Fecha;
        actual.Lugar = mision.Lugar;
        actual.CupoMaximo = mision.CupoMaximo;
        actual.Activo = mision.Activo;

        _context.SaveChanges();
        return true;
    }

    public bool Eliminar(int id)
    {
        var evento = _context.Eventos.Find(id);
        if(evento == null)
            return false;

        _context.Eventos.Remove(evento);
        _context.SaveChanges();
        return true;
    }
}