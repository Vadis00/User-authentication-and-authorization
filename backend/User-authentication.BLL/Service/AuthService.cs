﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<string> Login(string email, string password)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Login == email);

            if (user == null) return "Not Found";

            return "Found";
        }
    }
}
