using Azure.Core;
using tech_store.DbModels.Auth;

namespace tech_store.Services.TokenService
{
    public interface ITokenService
    {
        public string getStrUserId();
        public int getUserId();
        public string generateToken(User userDb);
    }
}
