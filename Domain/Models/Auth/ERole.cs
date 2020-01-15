using System.ComponentModel;

namespace Supermarket.API.Domain.Models.Auth
{
    public enum ERole
    {
        [Description("Common")] Common = 1,
        [Description("Administrator")] Administrator = 2
    }
}