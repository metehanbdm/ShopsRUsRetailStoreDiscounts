namespace ShopsRUsRetailStoreDiscountsApi.Models
{
    public class InvoiceItem
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsGrocery { get; set; }
    }
}