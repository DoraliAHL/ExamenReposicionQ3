using System.ComponentModel.DataAnnotations;

namespace ExamenReposicion.DTOs;

public class CrearGastoDTO
{
    [Required]
    [Range(0.01, double.MaxValue)]
    public double Monto { get; set; }

    [Required]
    public string Categoria { get; set; } = "";

    [Required]
    public string Descripcion { get; set; } = "";

    [Required]
    public DateTime Fecha { get; set; }
}