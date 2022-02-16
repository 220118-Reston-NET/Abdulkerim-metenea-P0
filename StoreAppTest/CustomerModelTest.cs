using System.Collections.Generic;
// using Moq;
using storeBL;
using storeDL;
using storeModel;
using Xunit;
namespace StoreAppTest;
public class CustomerDatabaseTest
{
    [Theory]
    [InlineData("Abdu")]
    [InlineData("Oliver")]
    [InlineData("Name")] // value should String
    public void SearchCustomer(string p_invalidname) // checks the value of Parameter should String
    {
           //Arrange
           Customer Cust = new Customer();
        //    string ValidName = "Abdu" ;
        //    //Act
        //    Cust.CustName = ValidName;
           //Assert
        //    Assert.NotNull(Cust.CustName); // checks the primary Key is not null
        //    Assert.Equal(ValidName, Cust.CustName); //chceks if the property holds the same value as setted

        Assert.IsNotType<System.Exception>(
        () => Cust.CustName = p_invalidname
        );
    }
    //    [Fact]
    // public void Should_Get_All_Customer()
    // {
    //     //Arrange
    //     string CustName = "Abdu";
    //     string CustPhone = "122 342 2342";
    //     Customer Cust = new Customer()
    //     {
    //         CustName = CustName,
    //         CustPhone = CustPhone
    //     };

    //     List<Customer> expectedListOfCustomer = new List<Customer>();
    //     expectedListOfCustomer.Add(Cust);

    //     //We are mocking one of the required dependencies of CustomerBL which is IRepository
    //     Mock<ICustRepo> mockRepo = new Mock<ICustRepo>();

    //     //We change that if our IRepository.GetAllCustomer() is called, it will always return our expectedListOfCustomer
    //     mockRepo.Setup(repo => repo.GetAllCustomer()).Returns(expectedListOfCustomer);

    //     //We passed in the mock version of IRepository
    //     ICustomerBL pokeBL = new CustomerBL(mockRepo.Object);

    //     //Act
    //     List<Customer> actualListOfCustomer = pokeBL.GetAllCustomer();

    //     //Assert
    //     Assert.Same(expectedListOfCustomer, actualListOfCustomer); //Checks if both list are the same thing
    //     Assert.Equal(CustName, actualListOfCustomer[0].CustName); //Checks the first element of actualListOfCustomer to have the same name
    //     Assert.Equal(CustPhone, actualListOfCustomer[0].CustPhone);//Checks the first element of actualListOfCustomer to have the same Phone

    // }
}