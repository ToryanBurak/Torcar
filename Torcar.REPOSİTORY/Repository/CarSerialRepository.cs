using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.Entity;
using Torcar.CORE.Repositories;

namespace Torcar.REPOSITORY.Repository
{
    public class CarSerialRepository:GenericRepository<CarSerial>,ICarSerialRepository
    {
        public CarSerialRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            
        }
    }
}
