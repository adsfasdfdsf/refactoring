namespace BookStore;

public class Book
{
    private double _price;
    private int _stock;
    public string Isbn { get; }
    public string Title { get; private set; }
    public string Author { get; private set; }

    public double Price
    {
        get => _price;
        private set => _price = value;
    }

    public int Stock
    {
        get => _stock;
        private set => _stock = value;
    }
    public bool IsAvailable { get; private set; }

    public Book(string isbn, string title, string author, double price, int stock)
    {
        if (price < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative");
        }

        if (stock < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(stock), "Stock cannot be negative");
        }
        Isbn = isbn;
        Title = title;
        Author = author;
        Price = price;
        Stock = stock;
        IsAvailable = true;
    }

    public void Rent()
    {
        if (Stock == 0)
        {
            throw new InvalidOperationException("Cannot rent stock is zero");
        }
        Stock--;
        if (Stock == 0)
        {
            IsAvailable = false;
        }
    }

    public void Return()
    {
        Stock++;
        IsAvailable = true;
    }

    public void Reprice(double newPrice)
    {
        if (newPrice < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(newPrice), "Price cannot be negative");
        }
        Price = newPrice;
    }

    public void Rename(string newTitle)
    {
        Title = newTitle;
    }

    public override string ToString()
    {
        return $"{Isbn} | {Title} | {Author} | {Price:0.00} | stock={Stock}";
    }
}