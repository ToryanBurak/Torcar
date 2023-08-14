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
    public class CarSerialService:GenericService<CarSerial>,ICarSerialService
    {
        private readonly ICarSerialRepository _carserialrepo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CarSerialService(IGenericRepository<CarSerial> serialrepo,ICarSerialRepository carserialrepo, IMapper mapper, IUnitOfWork unitOfWork):base(serialrepo,unitOfWork)
        {
            _carserialrepo = carserialrepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
}
