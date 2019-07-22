using System;
using System.Collections.Generic;

namespace eFormProcessingService.Models.DB
{
    public partial class PartyPropertyDetailsTransaction
    {
        public int Id { get; set; }
        public int? SalesDutyId { get; set; }
        public string Name { get; set; }
        public int? ProfileTypeId { get; set; }
        public int? CountyId { get; set; }
        public string PurchaseLiableAdditional { get; set; }
        public int? IdentityTypeId { get; set; }
        public string IdentityNumber { get; set; }
        public string MailingAddressCountry { get; set; }
        public int? PostalCodeId { get; set; }
        public string HouseNumber { get; set; }
        public string StreetNumber { get; set; }
        public string LevelUnit1 { get; set; }
        public string LevelUnit2 { get; set; }
        public int? TotalNumberOfOwned { get; set; }

        public virtual CountryMaster County { get; set; }
        public virtual IdentityTypeMaster IdentityType { get; set; }
        public virtual PostalCodeMaster PostalCode { get; set; }
        public virtual ProfileMaster ProfileType { get; set; }
        public virtual StampSaleAndPurchaseOfProperty SalesDuty { get; set; }
    }
}
