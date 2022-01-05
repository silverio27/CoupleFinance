using Microsoft.Azure.CosmosRepository;

namespace Infra
{
    public class UserModel : Item
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }

    }
}