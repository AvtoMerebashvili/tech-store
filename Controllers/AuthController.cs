using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tech_store.DbModels;
using tech_store.DbModels.Auth;

namespace tech_store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TechStoreContext _context;

        public AuthController(TechStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Roles")]
        public async Task<ActionResult<List<Role>>> getRoles()
        {
            return null;
        }


    }
}
