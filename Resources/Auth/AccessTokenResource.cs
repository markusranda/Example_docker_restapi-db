namespace Supermarket.API.Resources.Auth {

    public class AccessTokenResource {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public long Expiration { get; set; }
    }

}