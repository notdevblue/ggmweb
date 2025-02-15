using Microsoft.AspNetCore.Mvc;
using GGM.Application.Models;
using GGM.Foundation;
using GGM.Application.Protocol;
using System.Text.Json;
using System.Text.Json.Serialization;

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

        var res = new ResHelloworld_Hello()
        {
            Name = reqName,
            ServerTime = TimeHelper.GetServerTime(),
            Message = $"Hello {reqName}!",
        };

        _logger.LogInformation($"Hello({res.Message})");

        return new JsonResult(res, _serializerOptions);
    }

    private ILogger<HelloworldController> _logger;
    private static JsonSerializerOptions _serializerOptions = new JsonSerializerOptions()
    {
        PropertyNamingPolicy = null,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
}