using Microsoft.AspNetCore.Mvc;
using selling_used_items_app_backend.Model;
using selling_used_items_app_backend.Service;

namespace selling_used_items_app_backend.Controllers
{
    [ApiController]
    [Route("api/advertisements")]
    public class AdvertisementController : ControllerBase
    {
        private readonly AdvertisementService _advertisementService;

        public AdvertisementController(AdvertisementService advertisementService)
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
        public ActionResult<Advertisement> GetById(int id)
        {
            var advertisement = _advertisementService.GetById(id);
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
            return CreatedAtAction(nameof(GetById), new { id = advertisement.id }, advertisement);
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
    }
}