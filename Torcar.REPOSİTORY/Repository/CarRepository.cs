using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.Entity;
using Torcar.CORE.Repositories;
using Torcar.CORE.UnitOfWork;

namespace Torcar.REPOSITORY.Repository
{
    public class CarRepository:GenericRepository<Car>,ICarRepository
    {
       

        public CarRepository(AppDbContext appDbContext):base(appDbContext) { }
        
    }
}
