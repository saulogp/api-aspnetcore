namespace prjapicliente.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string MotherName { get; set; }
        public Address Address { get; set; }

    }
}
