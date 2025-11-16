namespace BookStore;

public class Catalog
{
    private Dictionary<string, Book> _items = new();
    private List<string> _order = new();
    
    public int Count { get; private set; }

    public void Add(Book book)
    {
        _items.Add(book.Isbn, book);

        Count++;
    }

    public bool Remove(string isbn)
    {
        return _items.Remove(isbn);
    }

    public bool Contains(string isbn)
    {
        return _items.ContainsKey(isbn);
    }

    public IEnumerable<Book> All()
    {
        foreach (var item in _items.Values)
        {
            yield return item;
        }
    }

    public Book this[string isbn]
    {
        get => _items[isbn];
    }

    public Book this[int index]
    {
        get => _items.ElementAt(index).Value;
    }
}