using AutoMapper;
using Torcar.CORE.Entity;
using Torcar.CORE.Repositories;
using Torcar.CORE.Service;
using Torcar.CORE.UnitOfWork;


namespace Torcar.SERVICE.Service
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        

        public UserService(IGenericRepository<User> per,IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userrepo):base(per, unitOfWork)
        {
            _mapper = mapper;
            _userRepository = userrepo;
            _unitOfWork = unitOfWork;
        }
    }
}
