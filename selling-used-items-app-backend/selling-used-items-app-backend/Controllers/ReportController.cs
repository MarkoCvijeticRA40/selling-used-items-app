using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using selling_used_items_app_backend.Model;
using selling_used_items_app_backend.Service;
using selling_used_items_app_backend.Validator.ReportValidator;

namespace selling_used_items_app_backend.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly ReportCreateValidator _reportCreateValidator;
        private readonly IEmailService _emailService;

        public ReportController(IReportService reportService, ReportCreateValidator reportCreateValidator, IEmailService emailService)
        {
            _reportService = reportService ?? throw new ArgumentNullException(nameof(reportService));
            _reportCreateValidator = reportCreateValidator ?? throw new ArgumentNullException(nameof(reportCreateValidator));
            _emailService = emailService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Report>> GetAll()
        {
            var reports = _reportService.GetAll();
            return Ok(reports);
        }

        [HttpPost]
        public IActionResult Create(Report report)
        {
            var validationResult = _reportCreateValidator.ValidateReport(report);
            if (validationResult != ValidationResult.Success)
            {
                return BadRequest(validationResult.ErrorMessage);
            }

            _reportService.Create(report);
            _emailService.SendEmailAsync("markodmnstrtr@gmail.com", "New report", report.reason);    
                        
            return Ok("Report created successfully.");
        }
    }
}
