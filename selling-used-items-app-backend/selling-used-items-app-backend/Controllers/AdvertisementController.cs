using Microsoft.AspNetCore.Mvc;
using selling_used_items_app_backend.Enum;
using selling_used_items_app_backend.Model;
using selling_used_items_app_backend.Service;
using selling_used_items_app_backend.UOW;
using selling_used_items_app_backend.Validator.AdvertisementValidator;
using System.ComponentModel.DataAnnotations;

namespace selling_used_items_app_backend.Controllers
{
    [ApiController]
    [Route("api/advertisements")]
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementService _advertisementService;
        private readonly AdvertisementCreateValidator _advertisementCreateValidator;
        private readonly AdvertisementUpdateValidator _advertisementUpdateValidator;
        private readonly AdvertisementDeleteValidator _advertisementDeleteValidator; 
        private readonly IPurchaseService _purchaseService;
        private readonly ApplicationDbContext _dbContext;

        public AdvertisementController(ApplicationDbContext dbContext, IPurchaseService purchaseService, IAdvertisementService advertisementService, AdvertisementCreateValidator advertisementCreateValidator, AdvertisementUpdateValidator advertisementUpdateValidator, AdvertisementDeleteValidator advertisementDeleteValidator)
        {
            _advertisementService = advertisementService;
            _advertisementCreateValidator = advertisementCreateValidator;
            _advertisementUpdateValidator = advertisementUpdateValidator;
            _advertisementDeleteValidator = advertisementDeleteValidator;
            _purchaseService = purchaseService;
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Advertisement>> GetAll()
        {
            var advertisements = _advertisementService.GetAll();
            return Ok(advertisements);
        }

        [HttpGet("{id}")]
        public ActionResult<Advertisement> Get(int id)
        {
            var advertisement = _advertisementService.Get(id);
            if (advertisement == null)
            {
                return NotFound();
            }
            return Ok(advertisement);
        }

        [HttpPost]
        public IActionResult Create(Advertisement advertisement)
        {
            var validationResult = _advertisementCreateValidator.ValidateAdvertisement(advertisement);
            if (validationResult != ValidationResult.Success)
            {
                return BadRequest(validationResult.ErrorMessage);
            }
            Console.WriteLine(advertisement);
            _advertisementService.Create(advertisement);
            return CreatedAtAction(nameof(Get), new { id = advertisement.id }, advertisement);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Advertisement advertisement)
        {
            if (id != advertisement.id)
            {
                return BadRequest("ID in the request path does not match the ID in the request body.");
            }
            var validationResult = _advertisementUpdateValidator.ValidateAdvertisement(advertisement);
            if (validationResult != ValidationResult.Success)
            {
                return BadRequest(validationResult.ErrorMessage);
            }
            _advertisementService.Update(advertisement);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var validationResult = _advertisementDeleteValidator.ValidateAdvertisement(id);
            if (validationResult != ValidationResult.Success)
            {
                return NotFound(validationResult.ErrorMessage);
            }
            _advertisementService.Delete(id);
            return NoContent();
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<Advertisement>> Search(string name = null, char? firstLetter = null, string sortBy = null)
        {
            var advertisements = _advertisementService.Search(name, firstLetter, sortBy);
            return Ok(advertisements);
        }

        [HttpPut("{advertisementId}/sell")]
        public IActionResult Sell(int advertisementId)
        {
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                try
                {
                    unitOfWork.BeginTransaction();

                    var advertisement = _advertisementService.Get(advertisementId);

                    if (advertisement == null)
                    {
                        return NotFound("Advertisement with the provided ID does not exist.");
                    }

                    advertisement.advertisementStatus = AdvertisementStatus.Sold;
                    _advertisementService.Update(advertisement);

                    var purchase = new Purchase
                    {
                        advertisementId = advertisementId,
                        userId = advertisement.userId,
                    };

                    _purchaseService.Create(purchase);

                    unitOfWork.SaveChanges();
                    unitOfWork.CommitTransaction();
                    return NoContent();
                }
                catch (Exception ex)
                {
                    unitOfWork.RollbackTransaction();
                    return StatusCode(500, "Error: " + ex.Message);
                }
            }
        }

        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<Advertisement>> GetByUserId(int userId)
        {
            var advertisements = _advertisementService.GetByUserId(userId);
            if (advertisements == null)
            {
                return NotFound("No advertisements found for the provided user ID.");
            }
            return Ok(advertisements);
        }

        [HttpGet("available")]
        public ActionResult<IEnumerable<Advertisement>> GetAllAvailable()
        {
            var advertisements = _advertisementService.GetAllAvailable();
            return Ok(advertisements);
        }
    }
}