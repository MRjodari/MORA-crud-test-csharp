using AutoMapper;
using Mc2.CrudTest.Application.Exceptions;
using Mc2.CrudTest.Application.Interfaces.Repos;
using MediatR;

namespace Mc2.CrudTest.Application.CQRS.Commands
{
    public class DeleteCustomerCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetById(request.Id);
            if (customer == null)
                throw new NotFoundException(nameof(customer), request.Id);

            customer.IsRemoved = true;
            customer.RemoveTime = DateTime.UtcNow;
            await _unitOfWork.CustomerRepository.Update(customer);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
