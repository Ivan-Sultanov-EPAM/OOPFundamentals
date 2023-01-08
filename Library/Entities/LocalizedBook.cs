namespace Library.Entities;

public class LocalizedBook : Book
{
    public string CountryOfLocalization { get; set; }
    public string LocalPublisher { get; set; }
}