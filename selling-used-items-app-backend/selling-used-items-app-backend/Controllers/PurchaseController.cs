using Microsoft.AspNetCore.Mvc;
using selling_used_items_app_backend.Model;
using selling_used_items_app_backend.Service;
using selling_used_items_app_backend.Validator.PurchaseValidator;
using System.ComponentModel.DataAnnotations;

namespace selling_used_items_app_backend.Controllers
{
    [ApiController]
    [Route("api/purchases")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        private readonly PurchaseCreateValidator _purchaseCreateValidator;

        public PurchaseController(IPurchaseService purchaseService, PurchaseCreateValidator purchaseCreateValidator)
        {
            _purchaseService = purchaseService ?? throw new ArgumentNullException(nameof(purchaseService));
            _purchaseCreateValidator = purchaseCreateValidator;
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
            var validationResult = _purchaseCreateValidator.ValidatePurchase(purchase);
            if (validationResult != ValidationResult.Success)
            {
                return BadRequest(validationResult.ErrorMessage);
            }
            _purchaseService.Create(purchase);
            return CreatedAtAction(nameof(GetPurchase), new { id = purchase.id }, purchase);
        }
    }
}