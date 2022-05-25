using AssetsManagement.DL.Helpres;
using AssetsManagement.DL.Interfaces;
using AssetsManagement.DL.Models;
using AssetsManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AssetsManagement.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetOperations ctx;
        private readonly IAuditOperations _auditContext;
        public AssetsController(IAssetOperations data, IAuditOperations audit)
        {
            ctx = data;
            _auditContext = audit;
        }

        [HttpGet("[action]")]
        public ResponseResult<List<Asset>> GetAllAssets()
        {
            var res = new ResponseResult<List<Asset>>();
            try
            {
                res.data = ctx.GetAssetsList();
            }
            catch (System.Exception ex)
            {
                res.serviceMessage = new ServiceMessage
                {
                    Severity = MessageSeverity.ERROR,
                    MessageText = ex.Message
                };
            }
            res.user = HttpContext.User?.Identity?.Name ?? "N/A";
            return res;
        }

        [HttpPost("[action]")]
        public IActionResult GetPagedAssets([FromQuery] PagingParams paging)
        {   
            var assets = ctx.GetPagedAssets(paging);
            var metadata = new
            {
                assets.TotalCount,
                assets.PageSize,
                assets.CurrentPage,
                assets.TotalPages,
                assets.HasNext,
                assets.HasPrevious
            };
            var user = HttpContext.User?.Identity?.Name ?? "N/A";
            return Ok(new { assets, user, paging = metadata });
        }
        [HttpPost("[action]")]
        public IActionResult GetPagedAssetsByUser([FromQuery] PagingParams paging, Guid uId)
        {
            var assets = ctx.GetPagedAssetsByUser(paging, uId);
            var metadata = new
            {
                assets.TotalCount,
                assets.PageSize,
                assets.CurrentPage,
                assets.TotalPages,
                assets.HasNext,
                assets.HasPrevious
            };
            var user = HttpContext.User?.Identity?.Name ?? "N/A";
            return Ok(new { assets, user, paging = metadata });
        }

        [HttpPost("[action]")]
        public async Task<Asset> GetAssetById([FromQuery] Guid Id)
        {
            //await Task.Delay(2000);
            return ctx.GetAssetById(Id);
        }

        [HttpPost("[action]")]
        public IActionResult GetAuditByAssetId([FromQuery] string Id, PagingParams paging)
        {            
            var audit = _auditContext.GetAuditByAssetId(Id, paging);
            var user = HttpContext.User?.Identity?.Name ?? "N/A";
            var metadata = new
            {
                audit.TotalCount,
                audit.PageSize,
                audit.CurrentPage,
                audit.TotalPages,
                audit.HasNext,
                audit.HasPrevious
            };
            return Ok(new { audit, user, paging = metadata });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateAssets([FromBody] Asset asset)
        {
            Debug.WriteLine(asset);
            await ctx.UpdateAsset(asset);
            return Ok();
        }

    }
}
