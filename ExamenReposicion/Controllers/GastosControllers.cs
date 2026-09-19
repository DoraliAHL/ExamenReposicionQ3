using ExamenReposicion.DTOs;
using ExamenReposicion.Models;
using ExamenReposicion.Services;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExamenReposicion.Controllers;

[ApiController]
[Route("api/gastos")]
[Authorize]
public class GastosController : ControllerBase
{
    private readonly FirebaseService _firebaseService;

    public GastosController(FirebaseService firebaseService)
    {
        _firebaseService = firebaseService;
    }

    [HttpPost]
    public async Task<IActionResult> CrearGasto(CrearGastoDTO dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized(new { message = "Usuario no identificado" });
        }

        var gasto = new Gasto
        {
            Monto = dto.Monto,
            Categoria = dto.Categoria,
            Descripcion = dto.Descripcion,
            Fecha = dto.Fecha,
            UserId = userId
        };

        DocumentReference docRef =
            await _firebaseService.FirestoreDb
                .Collection("gastos")
                .AddAsync(gasto);

        gasto.Id = docRef.Id;

        return Ok(new
        {
            message = "Gasto registrado correctamente",
            gasto
        });
    }
}