using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Model;

namespace Backend.Repository
{
    public class AlbumRepository : IRepository<Album>
    {
        public Task<IEnumerable<Album>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Album> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Album obj)
        {
            throw new NotImplementedException();
        }

        public Task Save(Album obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(Album obj)
        {
            throw new NotImplementedException();
        }
    }
}