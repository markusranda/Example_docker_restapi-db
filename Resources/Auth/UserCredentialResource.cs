using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Resources.Auth
{
    public class UserCredentialResource
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        public string Email { get; set; }

        [Required] [StringLength(32)] public string Password { get; set; }
    }
}