using Microsoft.AspNetCore.Identity;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Repositories.Implementations;
using Online_Store_Backend_WebAPI.Services.Authorization.Abstractions;

namespace Online_Store_Backend_WebAPI.Services.Authorization.Implementations {
    public class LoginService : ILoginService {
        private readonly IUserRepository _userRepo;
        private readonly PasswordHasher<UserVo> _passwordHasher;
        public LoginService(IUserRepository userRepository) {
            _userRepo = userRepository;
            _passwordHasher = new PasswordHasher<UserVo>();
        }

        private bool VerifyUser(UserVo user, string password) {
            var verify =_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            return verify == PasswordVerificationResult.Success || verify == PasswordVerificationResult.SuccessRehashNeeded;
        }

        public async Task<BasicResponseDto> Login(string email, string password) {

            var result = false;
            try {
                var user = await _userRepo.GetByEmail(email);
                result = VerifyUser(user, password);

            } catch(Exception ex) {
                //do something
            }

            return new BasicResponseDto()
            {
                Success = result,
                Message = result ? "Success" : "Login Failed"
            };
        }

        public async Task<BasicResponseDto> UpdateEmail(string oldEmail, string newEmail, string password) {
            var result = false;
            try {
                var user = await _userRepo.GetByEmail(oldEmail);
                var checkUser = await _userRepo.GetByEmail(newEmail);

                if(user == null || checkUser != null || VerifyUser(user, password)) {
                    throw new Exception("Update Error");
                }

                result = await _userRepo.UpdateEmail(user.Id, newEmail);
            } catch(Exception ex) {
                //do something
            }

            return new BasicResponseDto()
            {
                Success = result,
                Message = result ? "Email Updated" : "Failed to update"
            };
        }

        public async Task<BasicResponseDto> UpdatePassword(string email, string oldPassword, string newPassword) {
            var result = false;
            try {
                var user = await _userRepo.GetByEmail(email);
                if(user == null || !VerifyUser(user, oldPassword)) {
                    throw new Exception("Update Error");
                }

                result = await _userRepo.UpdatePassword(user.Id, newPassword);
            } catch(Exception ex) {
                //do something
            }

            return new BasicResponseDto()
            {
                Success = result,
                Message = result ? "Password Updated" : "Failed to update"
            };
        }
    }
}
