using Backend.Model;

namespace Backend.Repository
{
    public class UserRepository : BaseRepository<User>, IRepository<User>
    {
        public UserRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}