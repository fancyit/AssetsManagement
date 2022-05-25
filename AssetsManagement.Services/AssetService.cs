using AssetsManagement.DL;
using AssetsManagement.DL.Helpres;
using AssetsManagement.DL.Interfaces;
using AssetsManagement.DL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AssetsManagement.DL.Helpres.AssetCommon;

namespace AssetsManagement.Services
{
    public partial class AssetService : IAssetOperations
    {
        private readonly AppDBContext _context;

        public AssetService(AppDBContext appContext)
        {
            _context = appContext;
        }

        public Asset GetAssetById(Guid id)
        {
            return _context.Assets
                .Include(a => a.AssetCategory)
                .Include(a => a.Owner).ThenInclude(o => o.Manager)
                .Include(a => a.Stock)
                .Include(a => a.Invoice)
                .OrderBy(x => x.Name)
                .Where(a => a.Id == id).FirstOrDefault();
        }

        public List<Asset> GetAssetsList()
        {
            List<Asset> assets =
                 _context.Assets
                .Include(a => a.AssetCategory)
                .Include(a => a.Owner).ThenInclude(o => o.Manager)
                .Include(a => a.Stock)
                .Include(a => a.Invoice)           
                .ToList();
            return assets;
        }

        public PagedList<Asset> GetPagedAssets(PagingParams paging)
        {
            return PagedList<Asset>.ToPagedList(
                 _context.Assets
                .Include(a => a.AssetCategory)
                .Include(a => a.Owner).ThenInclude(o => o.Manager)
                .Include(a => a.Stock)
                .Include(a => a.Invoice)
                .OrderBy(x => x.Name),
                 paging.PageNumber, paging.PageSize);
        }

        public PagedList<Asset> GetPagedAssetsByUser(PagingParams paging, Guid uId)
        {
            return PagedList<Asset>.ToPagedList(
                 _context.Assets
                .Where(a => a.OwnerId == uId)
                .Include(a => a.AssetCategory)
                .Include(a => a.Owner).ThenInclude(o => o.Manager)                
                .Include(a => a.Stock)
                .Include(a => a.Invoice)
                .OrderBy(x => x.Name),
                 paging.PageNumber, paging.PageSize);
        }
        public Department GetDepartmentById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetDepartmentsList()
        {
            throw new NotImplementedException();
        }

        public Invoice GetInvoiceById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> GetInvoicesList()
        {
            throw new NotImplementedException();
        }
        public async Task<int> UpdateAsset(Asset asset)
        {
            var cur_asset = _context.Assets.Where(a => a.Id == asset.Id).FirstOrDefault();
            MergeEntries(ref cur_asset, asset);
            _context.Update(cur_asset);
            return await _context.SaveChangesAsync();
        }
    }
}


