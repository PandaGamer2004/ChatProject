using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.API.Controllers;


[Authorize]
[ApiController]
public class BaseApiController : ControllerBase
{
    
}