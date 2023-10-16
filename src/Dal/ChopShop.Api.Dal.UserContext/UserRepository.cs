using Microsoft.EntityFrameworkCore;

namespace ChopShop.Api.Dal.UserContext;

public class UserRepository
{
    private readonly DbSet<User> _dbSet;
    
    protected UserRepository(DbSet<User> dbSet) => _dbSet = dbSet;
    
    public async Task<User?> GetByIdAsync(int id) => await _dbSet.SingleOrDefaultAsync(user => user.Id == id);
}