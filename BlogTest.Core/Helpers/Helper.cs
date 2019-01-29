using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTest.Core.Helpers
{
    public class Helper
    {
        public Helper()
        {

        }

        // When setting password
        public string EncryptPassword(string password)
        {
            string hashedPassword = PasswordHash.HashPassword(password, PasswordHash.GenerateSalt());
            return hashedPassword;
        }

        // Upon login
        public bool ValidatePassword(string enteredPassword, string hashedPassword)
        {
            bool pwdHash = PasswordHash.CheckPassword(enteredPassword, hashedPassword);
            return pwdHash;
        }
    }
}
