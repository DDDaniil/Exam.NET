using Exam.DataObject;
using Microsoft.AspNetCore.Mvc;
using Exam.Enums;
using Exam.Services;


namespace Exam.Controllers
{
    [ApiController]
    [Route("credit")]
    public class CreditController : ControllerBase
    {
        private readonly CreditService _creditService;

        public CreditController(CreditService creditService)
        {
            _creditService = creditService;
        }
    
        [HttpPost("take")]
        public IActionResult TakeCredit([FromBody] CreditDataObject creditData)
        {
            var result = _creditService.GetCreditResult(creditData);
            return Ok(result);
        }
    }
}