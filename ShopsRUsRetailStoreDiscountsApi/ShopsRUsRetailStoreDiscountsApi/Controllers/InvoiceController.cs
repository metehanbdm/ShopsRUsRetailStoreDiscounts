using Microsoft.AspNetCore.Mvc;
using ShopsRUsRetailStoreDiscountsApi.Models;
using ShopsRUsRetailStoreDiscountsApi.Shared;

namespace ShopsRUsRetailStoreDiscountsApi.Controllers
{
    [ApiController]
    [Route("api/Invoice")]
    public class InvoiceController : ControllerBase
    {
        private readonly IDiscountCalculatorRepository _discountCalculator;

        public InvoiceController(IDiscountCalculatorRepository discountCalculator)
        {
            _discountCalculator = discountCalculator;
        }

        [HttpPost("CalculateDiscount")]
        public async Task<ActionResult> CalculateDiscount([FromBody] Invoice invoice)
        {
            decimal totalDiscount = await _discountCalculator.CalculateDiscount(invoice.Customer, invoice.Items);
            decimal totalAmount = invoice.Items.Sum(item => item.Price);
            decimal finalAmount = totalAmount - totalDiscount;

            return Ok(new { InvoiceAmount =  finalAmount });
        } 
    }
}