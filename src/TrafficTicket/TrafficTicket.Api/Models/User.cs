namespace TrafficTicket.Api.Models
{
    public class User
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Cargo { get; set; }

        public bool Active { get; set; }

        public DateTime CreatedAt { get; set; }

        public User()
        {
        }

        public User(string id)
        {
            Id = id;
        }
    }
}
