using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.Entity;
using Torcar.CORE.Enums;
using Torcar.CORE.Repositories;


namespace Torcar.REPOSITORY.Repository
{
    public class AdvertRepository:GenericRepository<Advert> ,IAdvertRepository
    {
       

        public AdvertRepository(AppDbContext appDbContext):base(appDbContext)
        {
            
        }
    }
}
