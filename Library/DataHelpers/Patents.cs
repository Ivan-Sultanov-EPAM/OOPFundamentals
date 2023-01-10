using Library.Entities;

namespace Library.DataHelpers;

public static class Patents
{
    public static Patent Patent1 = new()
    {
        Id = 1,
        Title = "LOCK OR UNLOCK INDICATOR ON A DATA STORAGE DEVICE",
        Authors = new List<string>
        {
            "Matthew Harris",
            "KLAPMAN"
        },
        DatePublished = new DateTime(2023, 1, 5),
        ExpirationDate = new DateTime(2025, 1, 5)
    };

    public static Patent Patent2 = new()
    {
        Id = 2,
        Title = "Lube oil controlled ignition engine combustion",
        Authors = new List<string>
        {
            "Sotiropoulou",
            "Maria-Emmanuella et al."
        },
        DatePublished = new DateTime(2018, 4, 15),
        ExpirationDate = new DateTime(2023, 4, 15)
    };

    public static Patent Patent3 = new()
    {
        Id = 3,
        Title = "CENTRIFUGAL COMPRESSOR AND TURBOCHARGER INCLUDING THE SAME",
        Authors = new List<string>
        {
            "IWAKIRI",
            "Kenichiro"
        },
        DatePublished = new DateTime(2021, 4, 29),
        ExpirationDate = new DateTime(2027, 4, 29)
    };
}