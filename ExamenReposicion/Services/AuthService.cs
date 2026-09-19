using Google.Cloud.Firestore;
using ExamenReposicion.DTOs;
using ExamenReposicion.Models;

namespace ExamenReposicion.Services;

public class AuthService
{
    private readonly FirestoreDb _db;

    public AuthService(FirebaseService firebase)
    {
        _db = firebase.FirestoreDb;
    }

    public async Task<(bool Ok, string Mensaje)> Register(RegisterDTO dto)
    {
        var usuarios = _db.Collection("usuarios");

        var existente = await usuarios
            .WhereEqualTo("Correo", dto.Correo)
            .GetSnapshotAsync();

        if (existente.Count > 0)
            return (false, "El correo ya está registrado");

        var doc = usuarios.Document();

        var usuario = new Usuario
        {
            Id = doc.Id,
            NombreCompleto = dto.NombreCompleto,
            Correo = dto.Correo,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Contrasena),
            Telefono = dto.Telefono,
            FechaNacimiento = dto.FechaNacimiento
        };

        await doc.SetAsync(usuario);

        return (true, "Usuario registrado correctamente");
    }

    public async Task<Usuario?> Login(LoginDTO dto)
    {
        var snapshot = await _db.Collection("usuarios")
            .WhereEqualTo("Correo", dto.Correo)
            .GetSnapshotAsync();

        if (snapshot.Count == 0)
            return null;

        var usuario = snapshot.Documents[0].ConvertTo<Usuario>();

        if (!BCrypt.Net.BCrypt.Verify(dto.Contrasena, usuario.PasswordHash))
            return null;

        return usuario;
    }
}