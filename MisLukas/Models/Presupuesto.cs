using System;
using System.ComponentModel.DataAnnotations;

namespace MisLukas.Models;

public class Presupuesto
{
    // Keys
    [Key]
    public int IdPresupuesto { get; set; }
    public int IdUsuario { get; set; }
    public int IdCategoria { get; set; }
    
    // Atributos
    public string? Periodo { get; set; }
    public double MontoLimite { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaTermino { get; set; }

    // Relaciones
    public Usuario Usuario { get; set; } = null!;
    public Categoria Categoria { get; set; } = null!;
}