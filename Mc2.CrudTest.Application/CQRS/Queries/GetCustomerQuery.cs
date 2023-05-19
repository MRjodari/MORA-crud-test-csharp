using AutoMapper;
using Mc2.CrudTest.Application.Interfaces.Repos;
using MediatR;

namespace Mc2.CrudTest.Application.CQRS.Queries
{
    public class GetCustomerQuery : IRequest<GetCustomerQueryResponse>
    {
        public long Id { get; set; }

    }
    public class GetCustomerQueryResponse
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }

    }
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetCustomerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetCustomerQueryResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetById(request.Id);
            var response = _mapper.Map<GetCustomerQueryResponse>(customer);
            await _unitOfWork.Save();
            return response;
        }
    }
}
