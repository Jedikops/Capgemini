using Capgemini.Models;
using Capgemini.Tests.XUnit.Fixtures;
using Capgemini.Tests.XUnit.TestData;
using Xunit;
using Xunit.Abstractions;

namespace Capgemini.Tests.Controllers
{
    [Collection("Controllers Collection")]
    [Trait("Category", "Customer API Controller")]
    public class CustomerApiControllerTests //: IClassFixture<ControllersFixture>
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly ControllersFixture _fixture;
      

        public CustomerApiControllerTests(ITestOutputHelper helper, ControllersFixture fixture)
        {
            _outputHelper = helper;
            _fixture = fixture;
        }

        [Fact]
        public void GetsCustomers()
        {
            var customers = _fixture.CustomerApiController.Get();
            Assert.NotNull(customers);
        }

        [Theory]
        [MemberData("CustomerIdAndName", MemberType = typeof(ControllersTestData))]
        public void ShouldUserWithIdHaveName(int id, string expected)
        {
            var customer = _fixture.CustomerApiController.Get(id);
            Assert.NotNull(customer);
            Assert.Equal(expected, customer.FirstName);
        }
    }


}
