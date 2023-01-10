namespace Library.Entities;

public class LocalizedBook : Book
{
    public string CountryOfLocalization { get; set; }
    public string LocalPublisher { get; set; }

    public override string ToString()
    {
        return $"ISBN: {ISBN}\n" +
               $"Title: {Title}\n" +
               $"Authors: {string.Join(", ", Authors)}\n" +
               $"Pages: {NumberOfPages}\n" +
               $"Date Published: {DatePublished:yyyy}\n" +
               $"CountryOfLocalization: {CountryOfLocalization}\n" +
               $"LocalPublisher: {LocalPublisher}";
    }
}