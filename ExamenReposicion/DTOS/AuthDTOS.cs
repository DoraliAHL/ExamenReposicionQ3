namespace ExamenReposicion.DTOs;

public class RegisterDTO
{
    public string NombreCompleto { get; set; } = "";
    public string Correo { get; set; } = "";
    public string Contrasena { get; set; } = "";
    public string Telefono { get; set; } = "";
    public string FechaNacimiento { get; set; } = "";
}

public class LoginDTO
{
    public string Correo { get; set; } = "";
    public string Contrasena { get; set; } = "";
}