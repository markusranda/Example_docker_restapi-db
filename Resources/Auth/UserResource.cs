using System.Collections.Generic;

namespace Supermarket.API.Resources.Auth {

    public class UserResource {
        public int Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }

}