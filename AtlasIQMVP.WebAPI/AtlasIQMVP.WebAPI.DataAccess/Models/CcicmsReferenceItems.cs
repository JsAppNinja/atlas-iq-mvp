using System;
using System.Collections.Generic;

namespace AtlasIQMVP.WebAPI.DataAccess.Models
{
    public partial class CcicmsReferenceItems
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public string Url { get; set; }
        public string Thumbnail { get; set; }
        public string Owner { get; set; }
        public string Copyright { get; set; }
        public string Description { get; set; }
    }
}
