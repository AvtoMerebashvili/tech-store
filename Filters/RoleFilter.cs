using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using tech_store.DbModels;
using tech_store.DbModels.Auth;
using tech_store.Services.TokenService;

namespace tech_store.Filters
{
    public class RoleFilter : ActionFilterAttribute, IAsyncActionFilter
    {
        private readonly string _roleNames;

        public RoleFilter(string roleNames )
        {
            _roleNames = roleNames;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var serviceProviderScope = context.HttpContext.RequestServices.CreateScope();
            var _tokenService = serviceProviderScope.ServiceProvider.GetRequiredService<ITokenService>();
            var _context = serviceProviderScope.ServiceProvider.GetRequiredService<TechStoreContext>();
            var userId = _tokenService.getUserId();
           
            var userRoles = await _context.users
                    .Where(x => x.id == userId)
                    .Include(x => x.Role)
                    .Where(x => x.Role.id == x.role_id)
                    .Select(x => x.Role.name.ToLower())
                    .ToArrayAsync();

            var neccessarryRoles = _roleNames.ToLower().Split(',');
            neccessarryRoles = Array.ConvertAll(neccessarryRoles, x => x.Trim());

            bool noIntersect = userRoles.Intersect(neccessarryRoles).Count() == 0;

            if(noIntersect)
            {
                return;
            }

            await next();
        }
    }
}
