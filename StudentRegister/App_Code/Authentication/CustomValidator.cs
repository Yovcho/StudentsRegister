using StudentRegister.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;

namespace StudentRegister.App_Code.Authentication
{
    public class CustomValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            AccountModel accountModel = new AccountModel();
            if (accountModel.Login(userName, password))
            {
                return;
            }
            
            throw new SecurityTokenException("403 Forbidden");
        }
    }
}