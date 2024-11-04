using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController] // Indicates that this controller provides API-specific features, such as automatic model validation.
    [Route("api/[controller]")] // Sets the base route for derived controllers to "api/[controller]" by default.
    public class BaseApiController : ControllerBase
    {

    }
}