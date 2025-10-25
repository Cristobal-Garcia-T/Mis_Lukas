using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MisLukas.Models;

public class Usuario
{
    // Keys
    [Key]
    public int IdUsuario { get; set; }
    
    // Atributos
    public string Nombre { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public DateTime FechaRegistro { get; set; }

    // Relaciones
    public List<Cuenta> Cuentas { get; set; } = new();
    public List<Presupuesto> Presupuestos { get; set; } = new();
    public List<Deuda> Deudas { get; set; } = new();
    public List<Categoria> Categorias { get; set; } = new();
}