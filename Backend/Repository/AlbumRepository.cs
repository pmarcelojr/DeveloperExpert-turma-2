using Backend.Model;

namespace Backend.Repository
{
    public class AlbumRepository : BaseRepository<Album>, IRepository<Album>
    {
        public AlbumRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}