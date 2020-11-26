using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WesternApparel.Core.Requests
{
    public class BrowseViewRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Category { get; set; }
    }
}
