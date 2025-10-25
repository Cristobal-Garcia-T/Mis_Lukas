using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MisLukas.Models;

public class Deuda
{
    // Keys
    [Key]
    public int IdDeuda { get; set; }
    public int IdUsuario { get; set; }

    // Atributos    
    public string Nombre { get; set; } = null!;
    public string Tipo { get; set; } = null!;
    public string Acreedor { get; set; } = null!;
    public double MontoAdeudado { get; set; }
    public double MontoPagado { get; set; }
    public double TasaInteres { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public DateTime FechaSiguienteCuota { get; set; }
    public double MontoCuota { get; set; }
    public int CuotasRestantes { get; set; }
    public string Estado { get; set; } = "Activa";
    public string? Comentario { get; set; }

    // Relaciones
    public Usuario Usuario { get; set; } = null!;
    public List<Gasto> Gastos { get; set; } = new();
    public List<ArchivoAdjunto> Archivos { get; set; } = new();
}