using System;
using System.Collections.Generic;

namespace eFormProcessingService.Models.DB
{
    public partial class DocumentTypeMaster
    {
        public DocumentTypeMaster()
        {
            StampSaleAndPurchaseOfProperty = new HashSet<StampSaleAndPurchaseOfProperty>();
        }

        public int Id { get; set; }
        public string DocumentName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<StampSaleAndPurchaseOfProperty> StampSaleAndPurchaseOfProperty { get; set; }
    }
}
