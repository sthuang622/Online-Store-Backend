using Microsoft.AspNetCore.Identity;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Repositories.Implementations;
using Online_Store_Backend_WebAPI.Services.Authorization.Abstractions;

namespace Online_Store_Backend_WebAPI.Services.Authorization.Implementations {
    public class AccountService : IAccountService {
        private readonly IUserRepository _userRepo;
        private readonly PasswordHasher<UserVo> _passwordHasher;
        public AccountService(IUserRepository userRepository, PasswordHasher<UserVo> passwordHasher) {
            _userRepo = userRepository;
            _passwordHasher = passwordHasher;
        }

        private bool VerifyUser(UserVo? user, string password) {
            if(user == null) return false;
            var verify =_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            return verify == PasswordVerificationResult.Success || verify == PasswordVerificationResult.SuccessRehashNeeded;
        }

        public async Task<BasicResponseDto> Login(string email, string password) {
            var user = await _userRepo.GetByEmail(email);
            var result = VerifyUser(user, password);


            return new BasicResponseDto()
            {
                Success = result,
                Message = result ? "Success" : "Login Failed"
            };
        }

        public async Task<BasicResponseDto> UpdateEmail(string oldEmail, string newEmail, string password) {
            var user = await _userRepo.GetByEmail(oldEmail);
            var checkUser = await _userRepo.GetByEmail(newEmail);

            if(user == null || checkUser != null || !VerifyUser(user, password)) {
                return new BasicResponseDto()
                {
                    Success = false,
                    Message = "Failed to update Email"
                };
            }

            var result = await _userRepo.UpdateEmail(user.Id, newEmail);

            return new BasicResponseDto()
            {
                Success = result,
                Message = result ? "Email Updated" : "Failed to update Email"
            };
        }

        public async Task<BasicResponseDto> UpdatePassword(string email, string oldPassword, string newPassword) {
            var user = await _userRepo.GetByEmail(email);
            if(user == null || !VerifyUser(user, oldPassword)) {
                throw new Exception("Update Error");
            }

            var result = await _userRepo.UpdatePassword(user.Id, _passwordHasher.HashPassword(user, newPassword));

            return new BasicResponseDto()
            {
                Success = result,
                Message = result ? "Password Updated" : "Failed to update Password"
            };
        }
    }
}
