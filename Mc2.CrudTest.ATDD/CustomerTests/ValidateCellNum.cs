using Mc2.CrudTest.Application.Interfaces.Repos;
using Mc2.CrudTest.ATDD.CustomerMock;
using Moq;
using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.ATDD.CustomerTests
{
    public class ValidateCellNum
    {
        private readonly Mock<IUnitOfWork> _mockRepository;
        public ValidateCellNum()
        {
            _mockRepository = MockUnitOfWork.GetUnitOfWork();

        }
        [Theory]
        [InlineData("+982187654321",false)]
        [InlineData("+989121234567",true)]
        [InlineData("+16156381234",true)]
        public Task ShouldBeBeAValidCellNumber(string phoneNumber,bool expecdation)
        {
            bool isMobile = false;
            
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            var resultPhoneNumber = phoneNumberUtil.Parse(phoneNumber, null);

            var numberType = phoneNumberUtil.GetNumberType(resultPhoneNumber);
            PhoneNumberType phoneNumberType = numberType;
            if((phoneNumberType == PhoneNumberType.FIXED_LINE) || (phoneNumberType == PhoneNumberType.MOBILE))
            {
                isMobile = true;
            }
             Assert.Equal(expecdation, isMobile);
            return Task.FromResult(isMobile);
        }
    }
}
