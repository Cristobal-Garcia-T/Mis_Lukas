using System;
using System.ComponentModel.DataAnnotations;

namespace MisLukas.Models;

public class ArchivoAdjunto
{
    // Keys
    [Key]
    public int IdArchivo { get; set; }
    
    // Atributos   
    public string EntidadTipo { get; set; } = null!; // "Gasto", "Ingreso", "Deuda"
    public int EntidadId { get; set; }
    public string NombreArchivo { get; set; } = null!;
    public string RutaRelativa { get; set; } = null!;
    public DateTime FechaSubida { get; set; }
}