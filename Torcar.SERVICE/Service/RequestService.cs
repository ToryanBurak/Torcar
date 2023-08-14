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
    public class RequestService:GenericService<RentRequest>,IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RequestService(IGenericRepository<RentRequest> repo,IRequestRepository requestrepo, IMapper mapper, IUnitOfWork unitOfWork):base(repo,unitOfWork)
        {
            _requestRepository = requestrepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
}
