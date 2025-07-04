interface IExpirable
{
    DateTime getExpirationDate();
    bool isExpired();
}