using Moq;
using ShopsRUsRetailStoreDiscountsApi.Models;
using ShopsRUsRetailStoreDiscountsApi.Shared;

[TestClass]
public class DiscountCalculatorTests
{
    [TestMethod]
    public void CalculateEmployeeDiscount_ShouldApply30PercentDiscount()
    {
        // Arrange
        var discountCalculator = new DiscountCalculator();
        var items = new List<InvoiceItem>
        {
            new InvoiceItem { Description = "Description1", Price = 50, IsGrocery = false },
            new InvoiceItem { Description = "Description2", Price = 100, IsGrocery = false }
        };
        var employee = new Customer { IsEmployee = true };

        // Act
        decimal discount = discountCalculator.CalculateEmployeeDiscount(items);

        // Assert
        Assert.AreEqual(45, discount); // 30% of (50 + 100) = 45
    }

    [TestMethod]
    public void CalculateBillDiscount_ShouldApply5DollarDiscountPer100Dollar()
    {
        // Arrange
        var discountCalculator = new DiscountCalculator();
        var items = new List<InvoiceItem>
        {
            new InvoiceItem { Description = "Description1", Price = 50, IsGrocery = false },
            new InvoiceItem { Description = "Description2", Price = 100, IsGrocery = false },
            new InvoiceItem { Description = "Description3", Price = 75, IsGrocery = false }
        };

        // Act
        decimal discount = discountCalculator.CalculateBillDiscount(items);

        // Assert
        Assert.AreEqual(10, discount); // $5 for every $100
    }

    [TestMethod]
    public void CalculateDiscount_ShouldApplyEmployeeDiscount()
    {
        // Arrange
        var discountCalculator = new DiscountCalculator();
        var items = new List<InvoiceItem>
    {
        new InvoiceItem { Description = "Item1", Price = 50, IsGrocery = false },
        new InvoiceItem { Description = "Item2", Price = 100, IsGrocery = false }
    };

        var mockCustomer = new Mock<Customer>();
        mockCustomer.Setup(c => c.IsEmployee).Returns(true);

        // Act
        decimal discount = discountCalculator.CalculateDiscount(mockCustomer.Object, items).Result;

        // Assert
        Assert.AreEqual(45, discount); // 30% of (50 + 100) = 45
    }

}
