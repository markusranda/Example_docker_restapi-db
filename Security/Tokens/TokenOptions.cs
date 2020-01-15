namespace Supermarket.API.Security.Tokens {

    public class TokenOptions {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public long AccessTokenExpiration { get; set; }
        public long RefreshTokenExpiration { get; set; }
        public long IssuedAt { get; set; }
    }

}