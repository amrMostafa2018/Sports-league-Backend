
namespace Task.Domain.Identity
{
    public class RefreshToken 
    {
        // Value of the Token
        public string TokenValue { get; set; }

        public string RefreshUserToken { get; set; }

        //public string AccessToken { get; set; }

        public DateTime ExpiryTime { get; set; }

        // The UserId it was issued to
        public long  UserIdentifier { get; set; }
    }
}
