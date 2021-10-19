using Microsoft.EntityFrameworkCore;
using RecordsModel.Model;
using System.Threading.Tasks;


namespace RecordsModel
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ApplicationDBContext _context;

        public DatabaseInitializer(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);
            //Insert a test user
            if (!await _context.Users.AnyAsync())
            {
                User newUser = new User();
                newUser.Password = "admin";
                newUser.Username = "admin";
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
            }
    
        }
    }
}
