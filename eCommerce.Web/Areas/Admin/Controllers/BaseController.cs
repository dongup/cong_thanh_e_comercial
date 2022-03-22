using eCommerce.Web.Areas.Api.Models.User;
using eCommerce.Web.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace eCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BaseController : Controller
    {
        public DatabaseContext _context;
        public UserResponse CurrentUser { get {
                try
                {
                    return  User == null ? null : GetUser(int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
                }
                catch
                {
                    return null;
                }
            } }

        public BaseController(DatabaseContext context)
        {
            _context = context;
        }

        protected UserResponse GetUser(int id)
        {
            return new UserResponse(_context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .Where(x => x.Id == id)
                .FirstOrDefault());
        }
    }
}
