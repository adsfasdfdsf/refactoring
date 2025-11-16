namespace BookStore;

static class Program
{
    static void Main(string[] args)
        {
           try
           {
               // Создание каталога и добавление книг
               var catalog = new Catalog();
               catalog.Add(new Book("978-5-4461-0923-5", "CLR via C#", "Jeffrey Richter", 55.0, 3));
               catalog.Add(new Book("978-0-1347-0779-3", "Clean Code", "Robert C. Martin", 48.5, 1));
               catalog.Add(new Book("978-1-1188-9912-4", "C# in Depth", "Jon Skeet", 52.9, 2));

               // Создание магазина
               var store = new BookStore(catalog);

               Console.WriteLine("=== Каталог при запуске ===");
               store.PrintCatalog();

               // Работа с индексатором по строке (ISBN)
               Console.WriteLine("\nПроверим книгу по ISBN:");
               var book = catalog["978-0-1347-0779-3"];
               Console.WriteLine($"Найдена книга: {book.Title} — Автор: {book.Author}");

               // Аренда книги
               Console.WriteLine("\nАренда книги 'Clean Code'");
               store.Rent("978-0-1347-0779-3");
               store.PrintCatalog();

               // Попытка арендовать снова (вызовет исключение)
               Console.WriteLine("\nПопытка снова арендовать 'Clean Code':");
               try
               {
                   store.Rent("978-0-1347-0779-3");
               }
               catch (Exception ex)
               {
                   Console.WriteLine($"Ошибка: {ex.Message}");
               }

               // Возврат книги
               Console.WriteLine("\nВозврат книги 'Clean Code'");
               store.Return("978-0-1347-0779-3");
               store.PrintCatalog();

               // Изменение цены
               Console.WriteLine("\nИзменение цены книги 'C# in Depth'");
               store.SetPrice("978-1-1188-9912-4", 59.9);
               store.PrintCatalog();

               // Проверка индексатора по номеру
               Console.WriteLine("\nКнига с индексом [0]:");
               Console.WriteLine(catalog[0]);

               // Удаление книги
               Console.WriteLine("\nУдаление книги 'CLR via C#'");
               catalog.Remove("978-5-4461-0923-5");
               store.PrintCatalog();
           }
           catch (Exception ex)
           {
               Console.WriteLine($"Глобальная ошибка: {ex.Message}");
           }

           Console.WriteLine("\nРабота программы завершена.");
       }
}