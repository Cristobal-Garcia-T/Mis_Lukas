using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MisLukas.Models;

public class Categoria
{
    // Keys
    [Key]
    public int IdCategoria { get; set; }
    public int IdUsuario { get; set; }
    
    // Atributos
    public string Nombre { get; set; } = null!;
    public string Tipo { get; set; } = null!; // "Gasto" o "Ingreso"

    // Relaciones
    public Usuario Usuario { get; set; } = null!;
    public List<Gasto> Gastos { get; set; } = new();
    public List<Ingreso> Ingresos { get; set; } = new();
    public List<Presupuesto> Presupuestos { get; set; } = new();
}