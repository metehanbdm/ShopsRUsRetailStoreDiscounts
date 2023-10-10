using ShopsRUsRetailStoreDiscountsApi.Models;

namespace ShopsRUsRetailStoreDiscountsApi.Shared
{
    public class DiscountCalculator : IDiscountCalculatorRepository
    {
        public Task<decimal> CalculateDiscount(Customer customer, List<InvoiceItem> items)
        {
            decimal totalDiscount = 0;

            if (customer.IsEmployee)
                totalDiscount = CalculateEmployeeDiscount(items);
            else if (customer.IsAffiliate)
                totalDiscount = CalculateAffiliateDiscount(items);
            else if (IsCustomerOver2Years(customer))
                totalDiscount = CalculateCustomerOver2YearsDiscount(items);

            totalDiscount += CalculateBillDiscount(items);

            return Task.FromResult(totalDiscount);
        }

        public decimal CalculateEmployeeDiscount(List<InvoiceItem> items)
        {
            // Calculate 30% discount for employees
            decimal nonGroceryTotal = items.Where(item => !item.IsGrocery).Sum(item => item.Price);
            return nonGroceryTotal * 0.3m;
        }

        private decimal CalculateAffiliateDiscount(List<InvoiceItem> items)
        {
            // Calculate 10% discount for affiliates
            decimal nonGroceryTotal = items.Where(item => !item.IsGrocery).Sum(item => item.Price);
            return nonGroceryTotal * 0.1m;
        }

        private decimal CalculateCustomerOver2YearsDiscount(List<InvoiceItem> items)
        {
            // Calculate 5% discount for customers over 2 years
            decimal nonGroceryTotal = items.Where(item => !item.IsGrocery).Sum(item => item.Price);
            return nonGroceryTotal * 0.05m;
        }

        private bool IsCustomerOver2Years(Customer customer)
        {
            return (DateTime.Now - customer.JoinDate).TotalDays >= 730; // 730 days = 2 years
        }

        public decimal CalculateBillDiscount(List<InvoiceItem> items)
        {
            // Calculate $5 discount for every $100 on the bill
            decimal totalAmount = items.Sum(item => item.Price);
            return Math.Floor(totalAmount / 100) * 5;
        }
    }

}
