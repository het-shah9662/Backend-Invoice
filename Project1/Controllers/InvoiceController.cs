using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Project1.BL;
using Project1.Models;
using System.Security.Cryptography;

namespace Project1.Controllers
{
    public class InvoiceController : ControllerBase
    {
        private readonly Interface _iservice;

        public InvoiceController(Interface iservice)
        {
            _iservice = iservice;
        }
  

        [Route("GetInvoice")]
        [HttpGet]

        public async Task<IActionResult> GetInvoice()
        {
            try
            {
                List<Item> items = await _iservice.GetAllInvoices();

                if (items == null)
                {
                    return NoContent();
                }
                else
                    return new ObjectResult(items);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }


        }
    }
}
