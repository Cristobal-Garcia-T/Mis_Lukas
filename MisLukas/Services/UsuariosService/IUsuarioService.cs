using System.Collections.Generic;
using System.Threading.Tasks;
using MisLukas.Models;

namespace MisLukas.Services.UsuariosService;

public interface IUsuarioService
{
    Task<Usuario> CrearAsync(string nombre, string password);
    Task<Usuario?> ObtenerPorNombreAsync(string nombre);
    Task<IEnumerable<Usuario>> ObtenerTodosAsync();
    Task<bool> ActualizarAsync(string nombre, string password);
    Task<bool> EliminarAsync(string nombre);
    Task<bool> ExisteUsuarioAsync(string nombre);
}