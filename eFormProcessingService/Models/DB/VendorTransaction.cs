using System;
using System.Collections.Generic;

namespace eFormProcessingService.Models.DB
{
    public partial class VendorTransaction
    {
        public int Id { get; set; }
        public int SalesDutyId { get; set; }
        public string IsActive { get; set; }
        public string VendorName { get; set; }
        public int? IdentityTypeId { get; set; }
        public decimal? IdentityNumber { get; set; }

        public virtual IdentityTypeMaster IdentityType { get; set; }
        public virtual StampSaleAndPurchaseOfProperty SalesDuty { get; set; }
    }
}
