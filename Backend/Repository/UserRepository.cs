using System;
using System.Threading.Tasks;
using Backend.Model;

namespace Backend.Repository
{
    public class UserRepository : IRepository<User>
    {
        public Task<System.Collections.Generic.IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(User obj)
        {
            throw new NotImplementedException();
        }

        public Task Save(User obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}