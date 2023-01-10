using Library.Entities;

namespace Library.DataHelpers;

public static class LocalizedBooks
{
    public static LocalizedBook LocalizedBook1 = new()
    {
        ISBN = "978-5-4461-0960-9",
        Title = "Чистый код. Создание, анализ и рефакторинг",
        Authors = new List<string>
        {
            "Мартин Роберт С."
        },
        Publisher = "Pearson",
        NumberOfPages = 464,
        DatePublished = new DateTime(2018, 01, 01),
        CountryOfLocalization = "Россия",
        LocalPublisher = "Питер"
    };

    public static LocalizedBook LocalizedBook2 = new()
    {
        ISBN = "978-5-4461-1595-2",
        Title = "Паттерны объектно-ориентированного проектирования",
        Authors = new List<string>
        {
            "Ральф Джонсон",
            "Джон Влиссидес",
            "Ричард Хелм",
            "Эрих Гамма"
        },
        Publisher = "Addison-Wesley Professional",
        NumberOfPages = 448,
        DatePublished = new DateTime(2020, 7, 10),
        CountryOfLocalization = "Россия",
        LocalPublisher = "Питер"
    };

    public static LocalizedBook LocalizedBook3 = new()
    {
        ISBN = "978-5-4461-1232-6",
        Title = "Непрерывное развитие API. Правильные решения в изменчивом технологическом ландшафте",
        Authors = new List<string>
        {
            "Меджуи М.",
            "Уайлд Э.",
            "Митра Р.",
            "Амундсен М."
        },
        Publisher = "O'Reilly Media, Inc.",
        NumberOfPages = 272,
        DatePublished = new DateTime(2020, 11, 22),
        CountryOfLocalization = "Россия",
        LocalPublisher = "Питер"
    };
}