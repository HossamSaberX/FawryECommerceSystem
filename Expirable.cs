class Expirable : Product, IExpirable
{
    public DateTime ExpirationDate { get; set; }

    public Expirable(string name, double price, int quantity, DateTime expirationDate) : base(name, price, quantity)
    {
        ExpirationDate = expirationDate;
    }

    public DateTime getExpirationDate()
    {
        return ExpirationDate;
    }
}