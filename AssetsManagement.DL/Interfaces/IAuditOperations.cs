using AssetsManagement.DL.Helpres;
using AssetsManagement.DL.Models;
using System;
using System.Collections.Generic;

namespace AssetsManagement.DL.Interfaces
{
    public interface IAuditOperations
    {
        public PagedList<AuditEntry> GetAuditByAssetId(string id, PagingParams paging);
    }
}
