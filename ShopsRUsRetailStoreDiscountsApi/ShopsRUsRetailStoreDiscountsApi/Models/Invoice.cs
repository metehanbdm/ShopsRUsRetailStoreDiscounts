namespace ShopsRUsRetailStoreDiscountsApi.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public List<InvoiceItem> Items { get; set; }
    }
}