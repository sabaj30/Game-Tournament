using GameTournamentApplication.Common.Errors;
using GameTournamentApplication.Common.Results;
using GameTournamentApplication.Services.AuthServices.DTOs;
using GameTournamentApplication.Services.JwtServices;
using GameTournamentDomain.Entities;
using GameTournamentInfrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GameTournamentApplication.Services.AuthServices
{
    public class AuthService : IAuthService
    {

        private readonly ChampionDbContext _championDbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtService _jwtService;
        public AuthService(
            ChampionDbContext championDbContext, 
            IPasswordHasher<User> passwordHasher, 
            IJwtService jwtService)
        {
            _championDbContext = championDbContext;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public async Task<Result<string>> AuthenticateUserAsync(string username, string password)
        {
            var user = await _championDbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(n=>n.UserName == username);

            if (user == null) 
            {
                return Result<string>.Failure(Error.Validation("نام کاربری یا رمز عبور اشتباه است"));
            }

            var verifyResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

            if (verifyResult == PasswordVerificationResult.Failed)
            {
                return Result<string>.Failure(Error.Validation("نام کاربری یا رمز عبور اشتباه است"));
            }

            var token = _jwtService.GenerateToken(user);

            return Result<string>.Success(token);

        }

        public async Task<Result> RegisterUserAsync(RegisterRequest request)
        {
            var userExists = await _championDbContext.Users
                .AnyAsync(x => x.UserName == request.UserName);

            if (userExists)
            {
                return Result.Failure(Error.Conflict("این نام کاربری قبلاً استفاده شده است"));
            }

            var emailExists = await _championDbContext.Users
                .AnyAsync(x => x.Email == request.Email);

            if (emailExists)
            {
                return Result.Failure(Error.Conflict("این ایمیل قبلاً استفاده شده است"));
            }

            var newUser = new User
            {
                Email = request.Email,
                UserName = request.UserName
            };

            var passwordHash = _passwordHasher.HashPassword(newUser, request.Password);

            newUser.PasswordHash = passwordHash;

            await _championDbContext.Users.AddAsync(newUser);
            await _championDbContext.SaveChangesAsync();

            return Result.Success();    
        }
    }
}
