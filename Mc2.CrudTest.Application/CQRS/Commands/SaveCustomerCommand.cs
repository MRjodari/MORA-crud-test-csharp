using AutoMapper;
using Mc2.CrudTest.Application.Interfaces.Repos;
using Mc2.CrudTest.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.CQRS.Commands
{
    public class SaveCustomerCommand : IRequest<SaveCustomerCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
    public class SaveCustomerCommandResponse
    {
        public long CustomerId { get; set; }
    }
    public class SaveCustomerCommandHandler : IRequestHandler<SaveCustomerCommand, SaveCustomerCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;     

        public SaveCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SaveCustomerCommandResponse> Handle(SaveCustomerCommand request, CancellationToken cancellationToken)
        {
            
            var customer = _mapper.Map<Customer>(request);

            await _unitOfWork.CustomerRepository.Add(customer);
            await _unitOfWork.Save();

            var response = new SaveCustomerCommandResponse
            {
                CustomerId = customer.Id
            };

            return response;
        }
    }
}
