using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MisLukas.Models;

namespace MisLukas.Services.UsuariosService;

public class UsuarioService : IUsuarioService
{
    private readonly SqLiteContext _db;

    public UsuarioService(SqLiteContext db)
    {
        _db = db;
    }

    public async Task<Usuario> CrearAsync(string nombre, string password)
    {
        var usuario = new Usuario
        {
            Nombre = nombre,
            PasswordHash = password, // TODO hashear la contraseña aquí
            FechaRegistro = DateTime.Now
        };
        _db.Usuarios.Add(usuario);
        await _db.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario?> ObtenerPorNombreAsync(string nombre)
    {
        return await _db.Usuarios.FirstOrDefaultAsync(u => u.Nombre == nombre);
    }

    public async Task<IEnumerable<Usuario>> ObtenerTodosAsync()
    {
        return await _db.Usuarios.ToListAsync();
    }

    public async Task<bool> ActualizarAsync(string nombre, string password)
    {
        var existente = await _db.Usuarios.FirstOrDefaultAsync(u => u.Nombre == nombre);
        if (existente == null) return false;

        existente.PasswordHash = password; // Recuerda hashear la contraseña aquí
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EliminarAsync(string nombre)
    {
        var usuario = await _db.Usuarios.FirstOrDefaultAsync(u => u.Nombre == nombre);
        if (usuario == null) return false;

        _db.Usuarios.Remove(usuario);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExisteUsuarioAsync(string nombre)
    {
        return await _db.Usuarios.AnyAsync(u => u.Nombre == nombre);
    }
}

