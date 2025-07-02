using ChatGpt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ChatGpt.Controllers
{

    [ApiController]
    public class DefaultController(IOptions<AppSetting> appSetting) : ControllerBase
    {
        [HttpGet("/")]
        public object Index()
        {
            return new
            {
                Test1 = 1,
                Test2 = "Test2",
                Test3 = DateTime.Now.ToLongDateString(),
                TestKeyVault = appSetting.Value.TestKey03
            };
        }

        [HttpGet("/ping")]
        public IActionResult Ping()
        {
            return Ok();
        }
    }
}
