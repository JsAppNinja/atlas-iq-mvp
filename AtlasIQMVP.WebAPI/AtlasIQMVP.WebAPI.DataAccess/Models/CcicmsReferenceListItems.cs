using System;
using System.Collections.Generic;

namespace AtlasIQMVP.WebAPI.DataAccess.Models
{
    public partial class CcicmsReferenceListItems
    {
        public int ListId { get; set; }
        public int ItemId { get; set; }
        public int? ParentId { get; set; }
        public int Ordering { get; set; }
        public int Id { get; set; }
    }
}
