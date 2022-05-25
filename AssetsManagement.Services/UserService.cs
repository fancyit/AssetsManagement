using AssetsManagement.DL;
using AssetsManagement.DL.Helpres;
using AssetsManagement.DL.Interfaces;
using AssetsManagement.DL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsManagement.Services
{
    public class UserService: IUserOperations
    {
        private readonly AppDBContext ctx;

        public UserService(AppDBContext context)
        {
            ctx = context;
        }

        public PagedList<Employee> GetUsersList(PagingParams pagingParams)
        {
            return PagedList<Employee>.ToPagedList(
                ctx.Employees,
                //.Include(e => e.Department),
                pagingParams.PageNumber, pagingParams.PageSize);
        }
        public async Task<List<Employee>> GetUsersList()
        {
            return await ctx.Employees
                    .Include(e => e.Department)
                    .ToListAsync();
        }

        public Employee GetUserById(Guid userId)
        {            
            return ctx.Employees
                .Include(e => e.Assets)
                .Include(e => e.Department)
                .Where(u => u.Id == userId).FirstOrDefault();
        }
    }
}
