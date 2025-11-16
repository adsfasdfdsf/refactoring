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
    public bool IsAvailable { get; }

    public Book(string isbn, string title, string author, double price, int stock)
    {
        if (price < 0 || stock < 0)
        {
            throw new ArgumentOutOfRangeException();
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
            throw new InvalidOperationException();
        }
        Stock--;
    }

    public void Return()
    {
        Stock++;
    }

    public void Reprice(double newPrice)
    {
        if (newPrice < 0)
        {
            throw new ArgumentOutOfRangeException();
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