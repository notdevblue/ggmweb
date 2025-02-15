using Microsoft.AspNetCore.Mvc;

namespace GGM.Application.Controllers;

[ApiController]
[Route("/api/helloworld")]
public class HelloWorldController : Controller
{
    [HttpGet("hello")]
    public string HelloWorld(string name, int count)
    {
        string response = "";

        for (int i = 0; i < count; ++i)
        {
            response += $"Hello {name}!\n";
        }

        return response;
    }

    [HttpGet("bye")]
    public string Bye(string name)
    {
        return $"Good bye, {name}!";
    }

    [HttpGet("hello2")]
    public string Hello2(int count)
    {
        return count.ToString();
    }
}
