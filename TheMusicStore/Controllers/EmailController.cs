using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TheMusicStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        public EmailController(IEmailSender emailSender)
        {
            _emailSender= emailSender;
        }
        [HttpGet]
        [Route("email")]
        public IEnumerable<EmailController> Get()
        {
            var rng = new Random();
            var message = new Message(new string[] { "aidabuza7@gmail.com" }, "Test email", "Content.");
            _emailSender.SendEmail(message);
            return null;
        }

        [HttpGet]
        [Route("emailAsync")]
        public async Task<IEnumerable<EmailController>> GetAsysnc()
        {
            var rng = new Random();
            var message = new Message(new string[] { "codemazetest@mailinator.com" }, "Test email async", "This is the content from our async email.");
            await _emailSender.SendEmailAsync(message);
            return null;
        }
    }
}
