using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MisLukas.Models;

public class Ingreso
{
    // Keys
    [Key]
    public int IdIngreso { get; set; }
    public int IdCuenta { get; set; }
    public int IdCategoria { get; set; }

    // Atributos
    public string? Origen { get; set; }
    public double Monto { get; set; }
    public DateTime Fecha { get; set; }
    public string? MetodoRecepcion { get; set; }
    public string? Comentario { get; set; }

    // Relaciones
    public Cuenta Cuenta { get; set; } = null!;
    public Categoria Categoria { get; set; } = null!;
    public List<ArchivoAdjunto> Archivos { get; set; } = new();
}