using Google.Cloud.Firestore;

namespace ExamenReposicion.Models;

[FirestoreData]
public class Usuario
{
    [FirestoreDocumentId]
    public string Id { get; set; } = "";

    [FirestoreProperty]
    public string NombreCompleto { get; set; } = "";

    [FirestoreProperty]
    public string Correo { get; set; } = "";

    [FirestoreProperty]
    public string PasswordHash { get; set; } = "";

    [FirestoreProperty]
    public string Telefono { get; set; } = "";

    [FirestoreProperty]
    public string FechaNacimiento { get; set; } = "";
}