using Microsoft.AspNetCore.Mvc;
using selling_used_items_app_backend.Model;
using selling_used_items_app_backend.Service;
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

        public AdvertisementController(IAdvertisementService advertisementService, AdvertisementCreateValidator advertisementCreateValidator, AdvertisementUpdateValidator advertisementUpdateValidator, AdvertisementDeleteValidator advertisementDeleteValidator)
        {
            _advertisementService = advertisementService;
            _advertisementCreateValidator = advertisementCreateValidator;
            _advertisementUpdateValidator = advertisementUpdateValidator;
            _advertisementDeleteValidator = advertisementDeleteValidator;
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
            var validationResult = _advertisementCreateValidator.ValidateAdvertisement(advertisement);
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
        public ActionResult<IEnumerable<Advertisement>> Search(string name = null, char? firstLetter = null, decimal? startPrice = null, decimal? endPrice = null)
        {
            var advertisements = _advertisementService.Search(name, firstLetter, startPrice, endPrice);
            return Ok(advertisements);
        }
    }
}