using Core.Entities.Concrete;
using Core.Extentions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class JWTHelper : ITokenHelper
    {
        public IConfiguration configuration { get; set; }
        private TokenOptions _tokenoptipns;
        private DateTime _accesstokenexpiration;
        public JWTHelper(IConfiguration configuration)
        {
            this.configuration = configuration;
            _tokenoptipns = configuration.GetSection(key: "TokenOptions").Get<TokenOptions>();
            _accesstokenexpiration = DateTime.Now.AddMinutes(_tokenoptipns.AccessTokenExpiration);
        }

      

        public AccessToken CreateToken(User user, List<OperationClaim> operationclaims)
        {

            var securitykey = SecurityKeyHelper.CreateSecurityKey(_tokenoptipns.SecurityKey);
            var signingcredentials = Signingcredentialhelper.CreateSigningCredential(securitykey);
            var jwt = CreateJwtSecurityToken(_tokenoptipns,user,signingcredentials,operationclaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _accesstokenexpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,User user, SigningCredentials signingCredentials,List<OperationClaim> operationclaims)
        {
            var jwt = new JwtSecurityToken(issuer: tokenOptions.Issuer, audience: tokenOptions.Audience, expires: _accesstokenexpiration, notBefore: DateTime.Now, claims: SetClaims(user, operationclaims), signingCredentials: signingCredentials);
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user,List<OperationClaim> operationclaims)
        {
           var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationclaims.Select(c=>c.Name).ToArray());
            return claims;
        }
    }
}
