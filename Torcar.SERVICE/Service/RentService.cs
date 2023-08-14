using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.Entity;
using Torcar.CORE.Repositories;
using Torcar.CORE.Service;
using Torcar.CORE.UnitOfWork;

namespace Torcar.SERVICE.Service
{
    public class RentService:GenericService<Rent>,IRentService
    {
        private readonly IRentRepository _rentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RentService(IGenericRepository<Rent> repo,IRentRepository rentRepository, IUnitOfWork unitOfWork, IMapper mapper):base(repo,unitOfWork)
        {
            _rentRepository = rentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
