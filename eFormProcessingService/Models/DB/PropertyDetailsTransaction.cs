using System;
using System.Collections.Generic;

namespace eFormProcessingService.Models.DB
{
    public partial class PropertyDetailsTransaction
    {
        public PropertyDetailsTransaction()
        {
            PropertyLevelUnitTransaction = new HashSet<PropertyLevelUnitTransaction>();
        }

        public int Id { get; set; }
        public int SalesDutyId { get; set; }
        public string IsActive { get; set; }
        public int? PostalCodeId { get; set; }
        public string HouseNumbe { get; set; }
        public string StreetName { get; set; }
        public int? PropertyTypeId { get; set; }
        public bool? PurchaseLiableToAdditionalBuyersStampDuty { get; set; }

        public virtual PostalCodeMaster PostalCode { get; set; }
        public virtual PropertyTypeMaster PropertyType { get; set; }
        public virtual StampSaleAndPurchaseOfProperty SalesDuty { get; set; }
        public virtual ICollection<PropertyLevelUnitTransaction> PropertyLevelUnitTransaction { get; set; }
    }
}
