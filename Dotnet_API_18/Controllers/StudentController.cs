using Dotnet_API_18.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_API_18.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(ApplicationDbContext _context) : ControllerBase
    {
        
    }
}
