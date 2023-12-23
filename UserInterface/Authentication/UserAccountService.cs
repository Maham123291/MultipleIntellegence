
using ModelLayer;
using UserInterface.Authentication;

namespace UserInterface.Authentication
{
    public class UserAccountService
    {
       
        public async Task<ModelMI> GetByUserName(String username,string userpass)
        {
            ModelMI ua = new ModelMI();
            ua =await DataAccessLayer.DALUserAuth.Authenticate(username, userpass);

            return ua;
        }
    }
}
