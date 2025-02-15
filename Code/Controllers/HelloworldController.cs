using Microsoft.AspNetCore.Mvc;
using GGM.Application.Models;
using GGM.Foundation;

namespace GGM.Application.Controllers;

[ApiController]
[Route("api/helloworld")]
public class HelloworldController : Controller
{
    public HelloworldController(
        ILogger<HelloworldController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public string Index()
    {
        return "wa!";
    }

    [HttpGet("hello")]
    public IActionResult Hello(string name)
    {
        var reqName = name;
        var res = new Helloworld()
        {
            Name = reqName,
            ServerTime = TimeHelper.GetServerTime(),
            Message = $"Hello {reqName}!",
        };

        _logger.LogInformation($"Hello()");

        return new JsonResult(res);
    }

    private ILogger<HelloworldController> _logger;
}