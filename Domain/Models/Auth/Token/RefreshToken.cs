namespace Supermarket.API.Domain.Models.Auth.Token {

    public class RefreshToken : JsonWebToken
    {
        public RefreshToken(string token, long expiration) : base(token, expiration)
        {
        }
    }
}