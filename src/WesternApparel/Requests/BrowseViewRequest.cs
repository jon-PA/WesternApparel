using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WesternApparel.Requests
{
    public class BrowseViewRequest
    {
        public int Page { get; set; } = 1;
        public string Category { get; set; }
    }
}
