using System;
using System.Collections.Generic;

namespace AtlasIQMVP.WebAPI.DataAccess.Models
{
    public partial class CcicmsReferenceLists
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string OwnerType { get; set; }
        public long OwnerId { get; set; }
        public int? Ordering { get; set; }
    }
}
