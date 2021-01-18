using Invoicing.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Invoicing.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly IBusinessData _data;

        public DashboardController(ILogger<DashboardController> logger, IBusinessData data)
        {
            _logger = logger;
            _data = data;
        }

        [HttpGet("{value}")]
        public ActionResult<decimal> GetData(string value)
        {
            if (value == "salesrevenue")
            {
                decimal salesrevenue = _data.AllInvoices.Sum(invoice => invoice.Amount);
                return salesrevenue;
            }
            else if (value == "outstanding")
            {
                decimal outstanding = _data.AllInvoices.Sum(invoice => invoice.Amount - invoice.Paid);
                return outstanding;
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }
      
    }
}
