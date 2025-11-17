namespace BookStore;

public class BookStore
{
    private Catalog _catalog;
    
    public Catalog Catalog
    {
        get => _catalog;
        private set => _catalog = value;
    }

    public BookStore(Catalog catalog)
    {
        Catalog = catalog;
    }

    public void Rent(string isbn)
    {
        Catalog[isbn].Rent();
    }

    public void Return(string isbn)
    {
        Catalog[isbn].Return();
    }

    public void SetPrice(string isbn, double price)
    {
        Catalog[isbn].Reprice(price);
    }

    public void PrintCatalog()
    {
        foreach (var item in Catalog.All())
        {
            Console.WriteLine(item.ToString());
        }
    }
}