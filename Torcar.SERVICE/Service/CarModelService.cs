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
    public class CarModelService:GenericService<CarModel>,ICarModelService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CarModelService(IGenericRepository<CarModel> modelrepo,ICarRepository carRepository, IMapper mapper, IUnitOfWork unitOfWork):base(modelrepo,unitOfWork)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
}
