using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MisLukas.Models;

public class Gasto
{
    //Keys
    [Key]
    public int IdGasto { get; set; }
    public int IdCuenta { get; set; }
    public int? IdDeuda { get; set; }
    public int IdCategoria { get; set; }

    //Atributos
    public string? Destino { get; set; }
    public double Monto { get; set; }
    public DateTime Fecha { get; set; }
    public string? MetodoPago { get; set; }
    public string? Comentario { get; set; }
    public string? Recurrencia { get; set; }

    // Relaciones
    public Cuenta Cuenta { get; set; } = null!;
    public Deuda? Deuda { get; set; }
    public Categoria Categoria { get; set; } = null!;
    public List<ArchivoAdjunto> Archivos { get; set; } = new();
}