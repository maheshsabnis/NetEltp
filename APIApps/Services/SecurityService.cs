using APIApps.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace APIApps.Services
{
    public class SecurityService
    {
        UserManager<IdentityUser> _useManager;
        SignInManager<IdentityUser> _signInManager;
        IConfiguration _configuration;

        public SecurityService(UserManager<IdentityUser> useManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _useManager = useManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }


        public async Task<SecureResponse> RegisterUserAsync(RegisterUser user)
        { 
            SecureResponse secureResponse = new SecureResponse();
            if (user == null)
            {
                secureResponse.Message = "Invalid User Info";
            }
            else
            {
                var regUser = new IdentityUser() { Email = user.Email, UserName = user.Email };
                // Create a new USer
                var result = await _useManager.CreateAsync(regUser, user.Password);
                if (result.Succeeded)
                {
                    secureResponse.Message = $"User {user.Email} is registered successfully";
                }
            }
            return secureResponse;
        }

        public async Task<SecureResponse> AuthUser(LoginUser user)
        { 
            SecureResponse secureResponse = new SecureResponse();

            // 1. Authenticate the user
            // 2 . if Success then generate token
            var regUser = new IdentityUser() { UserName = user.Email };

            var authStatus = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, lockoutOnFailure: true);

            if (authStatus.Succeeded)
            {
                secureResponse.Message = $"User {user.Email} is AUtenticated successfully";
                // Read Secret Key
                var secretKey = Convert.FromBase64String(_configuration["JWTCoreSettings:SecretKey"]);
                // Read Expiry
                var expiryTimeSpan = Convert.ToInt32(_configuration["JWTCoreSettings:ExpiryInMinuts"]);

                // CReate an IdenttyUSer object
                // this will be used fot creating Claim
                IdentityUser logUser = new IdentityUser(user.Email);

                // SecurityTokenDescriptor: Define the Information for
                // Generating Token
                var securityTokenDescription = new SecurityTokenDescriptor()
                {
                    Issuer = null, // LOcal Hosting ENv.
                    Audience = null,
                    // CUrrently Only USer NAme is addded in Claim
                    // MAke ure that do not put the
                    // Sensetive INfo in CLaims
                    Subject = new ClaimsIdentity(new List<Claim> {
                        new Claim("username",logUser.Id,ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(expiryTimeSpan),
                    IssuedAt = DateTime.UtcNow,
                    NotBefore = DateTime.UtcNow,
                    // Setting an Algorithm for Encryption
                    // and The Signeture
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
                };
                // Actually GeneratenJSON Web Token
                var jwtHandler = new JwtSecurityTokenHandler();
                // CReate Token based on Description
                var jwToken = jwtHandler.CreateJwtSecurityToken(securityTokenDescription);
                // Write Token in Response
                secureResponse.UserName = user.Email;
                secureResponse.Token = jwtHandler.WriteToken(jwToken);

            }
            else
            {
                secureResponse.Message = $"User {user.Email} is login failed";
            }


            return secureResponse;
        }
    }
}
