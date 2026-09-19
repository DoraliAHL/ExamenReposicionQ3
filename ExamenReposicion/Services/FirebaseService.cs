using Google.Cloud.Firestore;

namespace ExamenReposicion.Services;

public class FirebaseService
{
    public FirestoreDb FirestoreDb { get; }

    public FirebaseService(IWebHostEnvironment environment)
    {
        var path = Path.Combine(
            environment.ContentRootPath,
            "firebase-key.json"
        );

        Environment.SetEnvironmentVariable(
            "GOOGLE_APPLICATION_CREDENTIALS",
            path
        );

        FirestoreDb = FirestoreDb.Create("examenreposicion-ca987");
    }
}