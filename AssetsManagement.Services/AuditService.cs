using AssetsManagement.DL;
using AssetsManagement.DL.Helpres;
using AssetsManagement.DL.Interfaces;
using AssetsManagement.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AssetsManagement.Services
{
    public class AuditService : IAuditOperations
    {
        private readonly AppDBContext _ctx;
        
        public AuditService(AppDBContext context)
        {
            _ctx = context;
        }

        public PagedList<AuditEntry> GetAuditByAssetId(string id, PagingParams paging)
        {            
            return PagedList<AuditEntry>.ToPagedList(
                _ctx.AuditEntries.Where(x => x.PrimaryKeyValue == id), paging.PageNumber, paging.PageSize);
        }
    }
}
