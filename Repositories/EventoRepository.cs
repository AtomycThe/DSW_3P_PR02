using DSW_3P_PR02.Models;

namespace DSW_3P_PR02.Repositories;

public interface IEventoRepository
{
    List<Evento> ObtenerTodas();
    Evento? ObtenerPorId(int id);
    Evento Agregar(Evento nueva);
    bool Actualizar(int id, Evento mision);
    bool Eliminar(int id);
}