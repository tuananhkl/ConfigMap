using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConfigMap.Controllers;

[ApiController]
[Route("[controller]")]
public class EchoController : Controller
{
    [HttpGet]
    public string Get()
    {
        dynamic respone = new ExpandoObject();
        respone.HostName = Environment.MachineName;
        respone.LocalIpAddress = Request.HttpContext.Connection.LocalIpAddress.ToString();
        respone.RemoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
        respone.RequestHeaders = Request.HttpContext.Request.Headers;
        respone.EnvVars = Environment.GetEnvironmentVariables();
        return JsonConvert.SerializeObject(respone);
    }
    [Route("EnvVars/{name}")]
    [HttpGet]
    public string? GetEnvVariable(string name)
    {
        return Environment.GetEnvironmentVariable(name);
    }
}