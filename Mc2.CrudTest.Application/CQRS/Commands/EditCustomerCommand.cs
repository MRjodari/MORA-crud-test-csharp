using AutoMapper;
using Mc2.CrudTest.Application.Interfaces.Repos;
using Mc2.CrudTest.Domain.Entities;
using MediatR;

namespace Mc2.CrudTest.Application.CQRS.Commands
{
    public class EditCustomerCommand : IRequest<EditCustomerCommandResponse>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }

    public class EditCustomerCommandResponse
    {
        public long CustomerId { get; set; }
    }
    public class EditCustomerCommandHandler : IRequestHandler<EditCustomerCommand, EditCustomerCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EditCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<EditCustomerCommandResponse> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);


            await _unitOfWork.CustomerRepository.Update(customer);
            await _unitOfWork.Save();

            var response = new EditCustomerCommandResponse
            {
                CustomerId = customer.Id
            };

            return response;
        }
    }
}
