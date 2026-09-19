using Google.Cloud.Firestore;

namespace ExamenReposicion.Models;

[FirestoreData]
public class Gasto
{
    [FirestoreDocumentId]
    public string? Id { get; set; }

    [FirestoreProperty]
    public double Monto { get; set; }

    [FirestoreProperty]
    public string Categoria { get; set; } = "";

    [FirestoreProperty]
    public string Descripcion { get; set; } = "";

    [FirestoreProperty]
    public DateTime Fecha { get; set; }

    [FirestoreProperty]
    public string UserId { get; set; } = "";
}