using Library.Entities;

namespace Library.DataHelpers;

public class Magazines
{
    public static Magazine Magazine1 = new()
    {
        Title = "Bloomberg Businessweek",
        Publisher = "Bloomberg L.P.",
        ReleaseNumber = 2,
        DatePublished = new DateTime(2023, 1, 9)
    };

    public static Magazine Magazine2 = new()
    {
        Title = "Forbes",
        Publisher = "Integrated Whale Media Investments",
        ReleaseNumber = 4,
        DatePublished = new DateTime(2023, 1, 13)
    };

    public static Magazine Magazine3 = new()
    {
        Title = "Men's Health",
        Publisher = "Rodale, Inc",
        ReleaseNumber = 1,
        DatePublished = new DateTime(2023, 1, 1)
    };
}