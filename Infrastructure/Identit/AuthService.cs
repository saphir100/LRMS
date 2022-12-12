
//using Application.Common.Interfaces;
using Application.Common.Models.Identity;
using Infrastructure.Identit;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identit
{
    public class AuthService: IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        public AuthService(
            UserManager<ApplicationUser> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _jwtSettings = jwtSettings.Value;
            _signInManager= signInManager;
            _userManager= userManager;
        }


        public async Task<AuthResponse> Login(AuthRequest authRequest)
        {
            var user=await _userManager.FindByEmailAsync(authRequest.Email);
            if(user == null)
            {
                throw new Exception("User Not Found");
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName, authRequest.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                throw new Exception("Credentails arn't valid");

            }
            JwtSecurityToken jwtSecurityToken =await GenerateToken(user);
            AuthResponse response= new AuthResponse()
            {
                Id=user.Id,
                Token=new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email=user.Email,
                UserName=user.UserName,
            };
            return response;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var existRequest=await _userManager.FindByNameAsync(request.UserName);
            if(existRequest != null)
            {
                throw new Exception("Username already exist");
            }

            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,

            };
            var response = await _userManager.CreateAsync(user,request.Password);
            
            if (!response.Succeeded)
            {
                throw new Exception("Register Process Failed.");
            }
            var res = new RegistrationResponse
                {Id=""
            };

            return res;
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaim = await _userManager.GetClaimsAsync(user);
            var roles=await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            for (int i=0;i<roles.Count;i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }
            var claims=new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid",user.Id)

            }.Union(userClaim).Union(roleClaims);

            var symmetricSeccurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("84322CFB66934ECC86D547C5CF4F2EFC"));//_jwtSettings.Key));
            var signInCredentails = new SigningCredentials(symmetricSeccurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: "HRLeaveManagement",//_jwtSettings.Issuer,
                audience: "HRLeaveManagementUser",//_jwtSettings.Audience,
                claims = claims,
                expires: DateTime.UtcNow.AddMinutes(/*_jwtSettings.DurationInMinutes*/60),
                signingCredentials: signInCredentails);

            return jwtSecurityToken;
        }
    }
}
