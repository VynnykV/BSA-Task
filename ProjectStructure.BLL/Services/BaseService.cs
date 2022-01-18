using AutoMapper;
using ProjectStructure.DAL.Interfaces;

namespace ProjectStructure.BLL.Services
{
    public abstract class BaseService
    {
        private protected readonly IUnitOfWork _unitOfWork;
        private protected readonly IMapper _mapper;

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}