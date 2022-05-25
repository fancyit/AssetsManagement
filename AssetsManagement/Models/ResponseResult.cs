using AssetsManagement.DL.Models;

namespace AssetsManagement.Models
{
    public class Paging
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
    }
    public class ResponseResult<T> where T: class
    {
        public T data { get; set; }
        public Paging Pager { get; set; }
        public string user { get; set; }
        public ServiceMessage serviceMessage { get; set; }
    }
}
