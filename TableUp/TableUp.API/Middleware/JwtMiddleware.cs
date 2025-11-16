using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace TableUp.API.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _secret;

        public JwtMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _secret = config["Jwt:Secret"]; // sua chave secreta
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"]
                               .FirstOrDefault()?.Split(" ").Last();

            if (!string.IsNullOrWhiteSpace(token))
                AttachUserToContext(context, token);

            await _next(context);
        }

        private void AttachUserToContext(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_secret);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),

                    ValidateIssuer = false,
                    ValidateAudience = false,

                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                // Pega as claims
                var userId = jwtToken.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub).Value;
                var userName = jwtToken.Claims.First(c => c.Type == JwtRegisteredClaimNames.PreferredUsername).Value;

                // Registra esses dados no HttpContext
                context.Items["UserId"] = userId;
                context.Items["UserName"] = userName;
            }
            catch
            {
                // Se o token for inválido, simplesmente não adiciona nada ao contexto
            }
        }
    }
}