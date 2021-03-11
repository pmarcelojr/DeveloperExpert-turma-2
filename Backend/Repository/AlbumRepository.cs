using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class AlbumRepository : BaseRepository<Album>, IRepository<Album>
    {
        public AlbumRepository(AppDbContext context) : base(context)
        {   
        }

        public async Task<IList<Album>> GetAll()
        {
            return await Query.Include(x => x.Musics).ToListAsync();
        }

        public async Task<IList<Music>> GetMusicFromAlbum(Guid albumId)
        {
            return await Query.Include(x => x.Musics)
                                .Where(x => x.Id == albumId)
                                .SelectMany(x => x.Musics)
                                .ToListAsync();
        }

        public async Task<Music> GetMusic(Guid musicId)
        {
            return await Query.Include(x => x.Musics)
                                .SelectMany(x => x.Musics)
                                .FirstOrDefaultAsync(x => x.Id == musicId);
        }

        public new async Task<Album> GetByIdAsync(Guid id)
        {
            return await Query.Include(x => x.Musics)
                                .Where(x => x.Id == id)
                                .FirstOrDefaultAsync();
        }
    }
}