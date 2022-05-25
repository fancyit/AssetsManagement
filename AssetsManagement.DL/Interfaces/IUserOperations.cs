using AssetsManagement.DL.Helpres;
using AssetsManagement.DL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetsManagement.DL.Interfaces
{
    public interface IUserOperations
    {
        public PagedList<Employee> GetUsersList(PagingParams pagingParams);
        public Task<List<Employee>> GetUsersList();

        public Employee GetUserById(Guid userId);
    }
}
