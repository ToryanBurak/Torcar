using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.Entity;
using Torcar.CORE.Repositories;

namespace Torcar.REPOSITORY.Repository
{
    public class UserRepository :GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
