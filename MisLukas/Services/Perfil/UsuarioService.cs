using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MisLukas.Models;

namespace MisLukas.Services.Perfil;

public class UsuarioService : IUsuarioService
{
    private readonly SqLiteContext _db;

    public UsuarioService(SqLiteContext db)
    {
        _db = db;
    }

    public async Task<Usuario> CrearAsync(Usuario usuario)
    {
        _db.Usuarios.Add(usuario);
        await _db.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario?> ObtenerPorIdAsync(int id)
    {
        return await _db.Usuarios.FindAsync(id);
    }

    public async Task<IEnumerable<Usuario>> ObtenerTodosAsync()
    {
        return await _db.Usuarios.ToListAsync();
    }

    public async Task<bool> ActualizarAsync(Usuario usuario)
    {
        var existente = await _db.Usuarios.FindAsync(usuario.IdUsuario);
        if (existente == null) return false;

        existente.Nombre = usuario.Nombre;
        existente.PasswordHash = usuario.PasswordHash;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var usuario = await _db.Usuarios.FindAsync(id);
        if (usuario == null) return false;

        _db.Usuarios.Remove(usuario);
        await _db.SaveChangesAsync();
        return true;
    }

}