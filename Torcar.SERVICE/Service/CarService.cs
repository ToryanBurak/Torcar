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
    public class CarService:GenericService<Car>,ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CarService(IGenericRepository<Car> repo,ICarRepository carRepository, IMapper mapper, IUnitOfWork unitOfWork):base(repo,unitOfWork)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
}
