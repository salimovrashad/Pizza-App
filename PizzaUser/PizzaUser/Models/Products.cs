namespace PizzaUser.Models
{
    public class Products
    {
        private static int _id;
        public int Id;
        public Products()
        {
            _id++;
            Id = _id;
        }
        public string PizzaName { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"{Id}. {PizzaName} {Price}$";
        }
    }
}
