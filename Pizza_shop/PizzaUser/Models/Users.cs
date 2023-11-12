namespace PizzaUser.Models
{
    public class Users
    {
        
        private static int _id;
        public int Id;
        public Users()
        {
            _id++;
            Id = _id;
        }

        public string? Name { get; set; }
        
        public string? Surname { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public bool isAdmin { get; set; }

        public override string ToString()
        {
            return $"{Id}. {Name} {Surname} - {Username} Password: {Password}";
        }
    }
}
