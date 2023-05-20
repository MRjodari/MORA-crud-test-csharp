using FluentValidation;
using Mc2.CrudTest.Application.CQRS.Commands;
using PhoneNumbers;

namespace Mc2.CrudTest.Application.Validators
{
    public class SaveCustomerValidator : AbstractValidator<SaveCustomerCommand>
    {
        public SaveCustomerValidator()
        {
            RuleFor(fn => fn.FirstName)
                .NotNull().WithMessage("First Name cannot be null")
                .NotEmpty().WithMessage("Fist name cannot be empty")
                .MaximumLength(50)
                .MinimumLength(3);

            RuleFor(ln => ln.LastName)
                .NotNull().WithMessage("Last Name cannot be null")
                .NotEmpty().WithMessage("Last name cannot be empty")
                .MaximumLength(50)
                .MinimumLength(3);

            RuleFor(dob => dob.DateOfBirth)
                .Must(BeAValidDate).WithMessage("Date of Birth is not a valid date");

            RuleFor(dob => dob.PhoneNumber)
                .Must(BeAValidPhoneNumber).WithMessage("Phone number is not a valid phone number");

            RuleFor(dob => dob.Email)
                .EmailAddress().WithMessage("Email is not valid");

            RuleFor(dob => dob.BankAccountNumber)
                .Must(BeValidBankAccount).WithMessage("Bank Account number is not valid");

        }
        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
        private bool BeValidBankAccount(string bankAccountNumber)
        {
            // Which Bank in Which Country????!
            return true;
        }

        private bool BeAValidPhoneNumber(string phoneNumber)
        {
            bool isMobile = false;
            try
            {
                var phoneNumberUtil = PhoneNumberUtil.GetInstance();
                var resultPhoneNumber = phoneNumberUtil.Parse(phoneNumber, null);

                var numberType = phoneNumberUtil.GetNumberType(resultPhoneNumber);
                string phoneNumberType = numberType.ToString();
                if (!string.IsNullOrEmpty(phoneNumberType) && phoneNumberType == "MOBILE")
                {
                    isMobile = true;
                }
                return isMobile;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
