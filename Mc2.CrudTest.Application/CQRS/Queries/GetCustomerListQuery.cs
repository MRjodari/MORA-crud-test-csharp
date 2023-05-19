using AutoMapper;
using Mc2.CrudTest.Application.Interfaces.Repos;
using Mc2.CrudTest.Domain.Entities;
using MediatR;

namespace Mc2.CrudTest.Application.CQRS.Queries
{
    public class GetCustomerListQuery : IRequest<IEnumerable<Customer>>
    {
        public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, IEnumerable<Customer>>
        {

            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public GetCustomerListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<IEnumerable<Customer>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
            {
                var customer = await _unitOfWork.CustomerRepository.GetAll();
                var response = _mapper.Map<List<Customer>>(customer.ToList());
                await _unitOfWork.Save();
                return response;
            }

        }


    }
}
