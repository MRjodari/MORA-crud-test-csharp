using AutoMapper;
using Mc2.CrudTest.Application.CommonResponse;
using Mc2.CrudTest.Application.Interfaces.Repos;
using Mc2.CrudTest.Application.Validators;
using Mc2.CrudTest.Domain.Entities;
using MediatR;

namespace Mc2.CrudTest.Application.CQRS.Commands
{
    public class SaveCustomerCommand : IRequest<BaseCommandResponse>
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
    public class SaveCustomerCommandHandler : IRequestHandler<SaveCustomerCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SaveCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(SaveCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new SaveCustomerValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid == false)
            {
                return new BaseCommandResponse()
                {
                    Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList(),
                    IsSuccess = false,
                    Message = "Create Customer Failed"
                };
            }
            else
            {
                if (CustomerEmailExist(request.Email))
                {
                    return new BaseCommandResponse()
                    {
                        Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList(),
                        IsSuccess = false,
                        Message = "Email Exist"
                    };
                }
                if (CustomerBasaeInfoExist(request.FirstName, request.LastName, request.DateOfBirth))
                {
                    return new BaseCommandResponse()
                    {
                        Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList(),
                        IsSuccess = false,
                        Message = "First Name & Last Name & Date of Birth  Exist"
                    };
                }
                var customer = _mapper.Map<Customer>(request);

                await _unitOfWork.CustomerRepository.Add(customer);
                await _unitOfWork.Save();

                return new BaseCommandResponse()
                {
                    IsSuccess = true,
                    Message = "Create Customer Successfully"
                };
            }
        }

        private bool CustomerEmailExist(string email)
        {
            var xxx = _unitOfWork.CustomerRepository.GetAll().Result.ToList();
            var result = _unitOfWork.CustomerRepository.GetAll().Result.Any(x => x.Email == email);
            return result;
        }
        private bool CustomerBasaeInfoExist(string firstName, string lastName, DateTime dateOfBirth)
        {
            return _unitOfWork.CustomerRepository.GetAll().Result
                .Any(x => x.FirstName == firstName && x.LastName == lastName && x.DateOfBirth == dateOfBirth);
        }
    }
}
