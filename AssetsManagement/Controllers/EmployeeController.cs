using AssetsManagement.DL.Helpres;
using AssetsManagement.DL.Interfaces;
using AssetsManagement.DL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AssetsManagement.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IUserOperations uCtx;

        public EmployeeController(IUserOperations uCtx)
        {
            this.uCtx = uCtx;
        }

        [HttpPost("[action]")]
        public IActionResult GetPagedusers([FromQuery] PagingParams paging)
        {
            var users = uCtx.GetUsersList(paging);
            var metadata = new
            {
                users.TotalCount,
                users.PageSize,
                users.CurrentPage,
                users.TotalPages,
                users.HasNext,
                users.HasPrevious
            };
            var user = HttpContext.User?.Identity?.Name ?? "N/A";
            return Ok(new { users, user, paging = metadata });
        }

        [HttpPost("[action]")]
        public async Task<Employee> GetUserById([FromQuery] Guid Id)
        {
            //await Task.Delay(2000);
            return uCtx.GetUserById(Id);
        }

    }
}
