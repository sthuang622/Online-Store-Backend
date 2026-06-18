using Microsoft.EntityFrameworkCore;
using Online_Store_Backend_WebAPI.Models.VOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;
using Online_Store_Backend_WebAPI.DB;
using Microsoft.AspNetCore.Identity;
using Online_Store_Backend_WebAPI.DB.Data;

namespace Online_Store_Backend_WebAPI.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly AppDBContext _context;

    public UserRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<UserVo>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var items = await _context.Users
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return items
            .Select(item => item.ToVo())
            .ToList();
    }

    private async Task<User> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        var item = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);

        return item;
    }

    private async Task<User?> GetByEmailInternal(string email, CancellationToken cancellationToken = default) {
        var item = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(item => email == item.Email, cancellationToken);
        return item;
    }

    public async Task<UserVo?> GetByEmail(string email, CancellationToken cancellationToken = default) {
        var user = await GetByEmailInternal(email);
        return user?.ToVo();

    }

    public async Task<bool> UpdateEmail(ulong id, string newEmail) {
        try {
            var user = await GetByIdAsync(id);

            user.Email = newEmail;
            user.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        } catch(Exception ex) { return false; }

    }

    public async Task<bool> UpdatePassword(ulong id, string newPassword) {
        try {
            var user = await GetByIdAsync(id);

            user.PasswordHash = newPassword;
            user.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        } catch (Exception ex) { return false; }
    }
}
