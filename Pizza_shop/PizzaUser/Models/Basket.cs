using System.Diagnostics;

namespace PizzaUser.Models;

internal class Basket
{
    private static int _id;
    public int Id;
    public Basket()
    {
        _id++;
        Id = _id;
    }
    public string PizzaName { get; set; }
    public decimal TotalPrice { get; set; }
    public int Count { get; set; }
    public override string ToString()
    {
        return $"<<<<</ {Id}. {PizzaName} {TotalPrice}$ />>>>>";
    }
}
