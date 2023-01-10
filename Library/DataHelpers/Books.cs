using Library.Entities;

namespace Library.DataHelpers;

public static class Books
{
    public static Book Book1 = new()
    {
        ISBN = "9781541618510",
        Title = "The Art of Statistics: How to Learn from Data",
        Authors = new List<string>
        {
            "David Spiegelhalter"
        },
        Publisher = "Basic Books",
        NumberOfPages = 448,
        DatePublished = new DateTime(2019, 9, 3)
    };

    public static Book Book2 = new()
    {
        ISBN = "9780387948607",
        Title = "The Algorithm Design Manual",
        Authors = new List<string>
        {
            "Steven S. Skiena"
        },
        Publisher = "Springer",
        NumberOfPages = 486,
        DatePublished = new DateTime(1997, 11, 14)
    };

    public static Book Book3 = new()
    {
        ISBN = "9780387948607",
        Title = "Mesozoic Art: Dinosaurs and Other Ancient Animals in Art",
        Authors = new List<string>
        {
            "Steve White",
            "Darren Naish"
        },
        Publisher = "Bloomsbury Wildlife",
        NumberOfPages = 208,
        DatePublished = new DateTime(2022, 11, 22)
    };
}