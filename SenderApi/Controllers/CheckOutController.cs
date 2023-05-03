using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenderApi.Service;
using SenderApi.Utility;
using SharedApp.Model;

namespace SenderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckOutController : ControllerBase
    {
        private readonly IQueueService queueService;

        public CheckOutController(IQueueService queueService)
        {
            this.queueService = queueService;
        }
        [HttpPost]
        public async Task<IActionResult> CheckOut(Customer customer)
            {
          await   queueService.SendMessageAsync(customer,SharedResource.EmailNotificationQueue);
            return Ok("Message has been sent");
            }
    }
}
