using storeModel;
using Xunit;
namespace StoreAppTest;

public class OrdersModelTest
{
    [Fact]
    public void StoreIDShoudBeInt()
    {
        //Arrange
        Orders checkId = new Orders();
        int invalidId = 1;
        //Act
        checkId.StoreID = invalidId;
        //Assert
        Assert.NotNull(checkId.StoreID);
        Assert.Equal(invalidId, checkId.StoreID ); 
       
    }
    public void StoreIDShoud()
    {
        //Arrange
        Orders checkId = new Orders();
        int invalidId = 1;
        //Act
        checkId.StoreID = invalidId;
        //Assert
        Assert.NotNull(checkId.StoreID);
        Assert.Equal(invalidId, checkId.StoreID);

    }

}
