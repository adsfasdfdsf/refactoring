namespace BookStore;

public class Catalog
{
    private Dictionary<string, Book> _items = new();
    private List<string> _order = new(); 
    
    public int Count => _items.Count;

    public void Add(Book book)
    {
        _items.Add(book.Isbn, book);
        _order.Add(book.Isbn); 
    }

    public bool Remove(string isbn)
    {
        if (_items.Remove(isbn))
        {
            _order.Remove(isbn); 
            return true;
        }
        return false;
    }

    public bool Contains(string isbn)
    {
        return _items.ContainsKey(isbn);
    }

    public IEnumerable<Book> All()
    {
        foreach (var isbn in _order)
        {
            yield return _items[isbn];
        }
    }

    public Book this[string isbn] => _items[isbn];

    public Book this[int index]
    {
        get
        {
            if (index < 0 || index >= _order.Count)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(index),
                    index,
                    $"Index {index} is out of range. Must be between 0 and {_order.Count - 1}."
                );
            }
            
            string isbn = _order[index];
            return _items[isbn];
        }
    }
}