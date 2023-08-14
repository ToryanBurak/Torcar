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
    public class CarMarkService:GenericService<CarMark>,ICarMarkService
    {
        private readonly ICarMarkRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CarMarkService(IGenericRepository<CarMark> markrepo,ICarMarkRepository repository, IMapper mapper, IUnitOfWork unitOfWork):base(markrepo,unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
}
