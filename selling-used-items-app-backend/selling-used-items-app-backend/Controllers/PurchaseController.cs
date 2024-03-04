using Microsoft.AspNetCore.Mvc;
using selling_used_items_app_backend.Model;
using selling_used_items_app_backend.Service;

namespace selling_used_items_app_backend.Controllers
{
    [ApiController]
    [Route("api/purchases")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService ?? throw new ArgumentNullException(nameof(purchaseService));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Purchase>> GetAllPurchases()
        {
            var purchases = _purchaseService.GetAll();
            return Ok(purchases);
        }

        [HttpGet("{id}")]
        public ActionResult<Purchase> GetPurchase(int id)
        {
            var purchase = _purchaseService.Get(id);
            if (purchase == null)
            {
                return NotFound();
            }
            return Ok(purchase);
        }

        [HttpPost]
        public IActionResult CreatePurchase(Purchase purchase)
        {
            _purchaseService.Create(purchase);
            return CreatedAtAction(nameof(GetPurchase), new { id = purchase.id }, purchase);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePurchase(int id, Purchase purchase)
        {
            if (id != purchase.id)
            {
                return BadRequest();
            }

            _purchaseService.Update(purchase);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePurchase(int id)
        {
            _purchaseService.Delete(id);
            return NoContent();
        }
    }
}