using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Resources.Auth {

    public class RevokeTokenResource {
        [Required] public string Token { get; set; }
    }

}