using LibraryAuthentication.Controller;
using LibraryAuthentication.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAuthentication
{
    public class JwtTokenHandler
    {

        public static string JWT_SECURITY_KEY = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiTmd1eWVuWHVhblRpZW5EdW5nIiwicm9sZSI6IkFkbWlucyIsIm5iZiI6MTcxNzgzNTQ4NywiZXhwIjoxNzE3ODM2Njg3LCJpYXQiOjE3MTc4MzU0ODd9.rbp_ZtnbrB2asJ7EQJxWjUWfEHHPvNpXri4KGi-ozI0";
        private const int JWT_TOKEN_VALIDITY_MINS = 1;
        //public JwtTokenHandler()
        //{
        //    JWT_SECURITY_KEY = GenerateRandomKey();
        //}

        private string GenerateRandomKey()
        {
            const int keyLength = 32; // 32 bytes = 256 bits
            byte[] keyBytes = new byte[keyLength];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(keyBytes);
            }
            return Convert.ToBase64String(keyBytes);
        }




        public AuthenticationResponse? GenerateJwToken(AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrWhiteSpace(authenticationRequest.UserName) || string.IsNullOrWhiteSpace(authenticationRequest.Password))
                return null;
            
            var userAccount = Connect.SelectSingle<User>("Select * from Users where Username = '"+authenticationRequest.UserName+"' and Password = '"+authenticationRequest.Password+"'");
            var role = Connect.SelectSingle<Role>("Select * from Role Where IdRole='"+userAccount.IdRole+"'");
            if (userAccount == null) return null;

            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var TokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            string userName = authenticationRequest.UserName.ToString(); // Chuyển đổi thành chuỗi
            var claimsIdentity = new ClaimsIdentity(new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Name, userName),
                new Claim(ClaimTypes.Role, role.NameRole)
            });


            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(TokenKey),
                SecurityAlgorithms.HmacSha256Signature
            );

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthenticationResponse
            {
                UserName = userAccount.Username,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                JwtToken = token,
            };
        }
    }
}
