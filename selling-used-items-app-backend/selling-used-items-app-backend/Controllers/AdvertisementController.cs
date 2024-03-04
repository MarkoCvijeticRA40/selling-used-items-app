using Microsoft.AspNetCore.Mvc;
using selling_used_items_app_backend.Model;
using selling_used_items_app_backend.Service;

namespace selling_used_items_app_backend.Controllers
{
    [ApiController]
    [Route("api/advertisements")]
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementService _advertisementService;

        public AdvertisementController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService ?? throw new ArgumentNullException(nameof(advertisementService));
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
            _advertisementService.Create(advertisement);
            return CreatedAtAction(nameof(Get), new { id = advertisement.id }, advertisement);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Advertisement advertisement)
        {
            if (id != advertisement.id)
            {
                return BadRequest();
            }

            _advertisementService.Update(advertisement);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _advertisementService.Delete(id);
            return NoContent();
        }

        [HttpPost("search")]
        public ActionResult<IEnumerable<Advertisement>> Search(string name = null, char? firstLetter = null, decimal? startPrice = null, decimal? endPrice = null)
        {
            var advertisements = _advertisementService.Search(name, firstLetter, startPrice, endPrice);
            return Ok(advertisements);
        }
    }
}