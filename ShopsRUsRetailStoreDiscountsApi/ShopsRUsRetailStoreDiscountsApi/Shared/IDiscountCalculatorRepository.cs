using ShopsRUsRetailStoreDiscountsApi.Models;

namespace ShopsRUsRetailStoreDiscountsApi.Shared
{
    public interface IDiscountCalculatorRepository
    { 
        Task<decimal> CalculateDiscount(Customer customer, List<InvoiceItem> items);
    }
}
