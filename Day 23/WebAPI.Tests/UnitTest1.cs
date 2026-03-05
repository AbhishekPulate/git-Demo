namespace WebAPI.Tests;

using WebAPI;
using DataAccessLayer;
using FakeItEasy;

public class UnitTest1
{
    [Fact]
    //[Theory]
    //[InlineData(1, 2, 3, 4)]
    public void Customer_CalculateInterest_ReturnsCorrectValue()
    // public void Customer_CalculateInterest_ReturnsCorrectValue(int duration, int principal, int rate, int expectedInterest)
    {
        // Arrange
        // controller, services
        ICustomerService customerService = A.Fake<ICustomerService>();

        A.CallTo(() => customerService.GetAllCustomers()).Returns(new List<Customer>
        {
            new Customer
            {
                Id = 3,
                Name = "Sarah Smith",
                Email = "sarah.smith@example.com"
            }
        });

        var customerController = new CustomerController(customerService);

        var expectedResult = new
        {
            StatusCode = 200,
            Value = new List<Customer> {
            new Customer
            {
                Id = 3,
                Name = "Sarah Smith",
                Email = "sarah.smith@example.com"
            }
        }
        };

        // Act
        var actualResult = customerController.Get();


        // Assert
        // Check of Status Code is 200
        // Check of Interest is correct
        //Assert.Equal(expectedResult.StatusCode, actualResult.StatusCode);
    }
}