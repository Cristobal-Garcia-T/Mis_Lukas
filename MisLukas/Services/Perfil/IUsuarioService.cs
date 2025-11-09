using System.Collections.Generic;
using System.Threading.Tasks;
using MisLukas.Models;

namespace MisLukas.Services.Perfil;

public interface IUsuarioService
{
    Task<Usuario> CrearAsync(Usuario usuario);
    Task<Usuario?> ObtenerPorIdAsync(int id);
    Task<IEnumerable<Usuario>> ObtenerTodosAsync();
    Task<bool> ActualizarAsync(Usuario usuario);
    Task<bool> EliminarAsync(int id);
}