using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public static class Encriptador
    { 

        // Aca estoy usando el encriptador SHA256
        public static string Hash(string value)
    {
        using (var sha256 = new SHA256Managed())
        {
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
            return Convert.ToBase64String(hash);
        }
    }

    }

}
