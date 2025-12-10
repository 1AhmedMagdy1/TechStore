using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Sharing
{
    public class ProductParams
    {
        public string Sort { get; set; }="asc";
        public int PageNumber { get; set; } = 1;
        private int pageSize = 5;
        private int MaxPageSize { get; set; } = 16;
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? Stars { get; set; }
        public string? SearchKeyWord { get; set; }
        public int PageSize {
            get { return pageSize; }
            set { pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }
        public int? CategoryId { get; set; }
        public int TotalCount { get; set; } = 0;

    }
}
