using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreateHashPassword(string password,out byte[] hashPassword,out byte[] saltPassword){
            using (var hmac= new System.Security.Cryptography.HMACSHA512())
            {
                saltPassword = hmac.Key;
                hashPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPasswordHash(string password,byte[] hashPassword,byte[] saltPassword)
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512(saltPassword))
            {
             var  ControlhashPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < ControlhashPassword.Length; i++)
                {
                    if (ControlhashPassword[i] != hashPassword[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
