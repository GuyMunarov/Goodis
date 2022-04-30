﻿using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Services
{
    public class HashingService : IHashingService
    {
        public void HashPassword(string password, out byte[] hash, out byte[] salt)
        {
            using var hmac = new HMACSHA512();
            hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            salt = hmac.Key;

        }

        public bool CheckHashEquality(string password, byte[] userHash, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);
            byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != userHash[i]) return false;
            }
            return true;
        }
    }
}
