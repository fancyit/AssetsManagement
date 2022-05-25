using AssetsManagement.DL.Helpres;
using AssetsManagement.DL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetsManagement.DL.Interfaces
{
    public interface IAssetOperations
    {
        // get        
        public Department GetDepartmentById(Guid id);
        public Invoice GetInvoiceById(Guid id);
        public Asset GetAssetById(Guid id);
        public PagedList<Asset> GetPagedAssets(PagingParams paging);
        public PagedList<Asset> GetPagedAssetsByUser(PagingParams paging, Guid uId);
        public List<Asset> GetAssetsList();
        public List<Invoice> GetInvoicesList();
        public List<Department> GetDepartmentsList();

        // update
        public Task<int> UpdateAsset(Asset asset);

        // delete
    }
}
