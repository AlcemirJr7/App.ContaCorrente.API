using App.ContaCorrente.Domain.Validacoes;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Entidades
{
    public class LoginCorrentista
    {

        public string Senha { get; protected set; }

        public string SenhaConfirmacao { get; protected set; }
        
        public string CriaHash(string senha)
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RSACryptoServiceProvider())
            {
                rngCsp.EncryptValue(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                            password: senha,
                            salt: salt,
                            prf: KeyDerivationPrf.HMACSHA256,
                            iterationCount: 100000,
                            numBytesRequested: 256 / 8));

            return hashed;
        }                  
       
    }
}
