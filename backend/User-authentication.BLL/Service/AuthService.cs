using Microsoft.EntityFrameworkCore;
using User_authentication.Common.Model;
using User_authentication.DAL;

namespace User_authentication.BLL.Service
{
    public class AuthService
    {
        DataContext db;
        public AuthService(DataContext db)
        {
            this.db = db; 
        }

        public async Task<string> AuthenticateUser(string email, string password)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Login == email) ?? throw new Exception("Not Found");

            return "Found";
        }
    }
}
