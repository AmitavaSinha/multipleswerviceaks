using System;
using System.Collections.Generic;

namespace eFormProcessingService.Models.DB
{
    public partial class StampSaleAndPurchaseOfProperty
    {
        public StampSaleAndPurchaseOfProperty()
        {
            PartyPropertyDetailsTransaction = new HashSet<PartyPropertyDetailsTransaction>();
            PropertyDetailsTransaction = new HashSet<PropertyDetailsTransaction>();
            VendorTransaction = new HashSet<VendorTransaction>();
        }

        public int Id { get; set; }
        public string StampSaleAndPurchaseOfPropertyId { get; set; }
        public string IsActive { get; set; }
        public bool? AreYouStampingYourOwnDocument { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string EamilId { get; set; }
        public int? DocumentTypeId { get; set; }
        public DateTime? DateOfTheDocument { get; set; }
        public DateTime? OverseasDate { get; set; }
        public decimal? PurchasePriseOrConsideration { get; set; }
        public string ShareOfPropertyTransferred { get; set; }
        public decimal? FloorArearSqm { get; set; }
        public string DocumentUrl { get; set; }
        public string DocumentRefNumber { get; set; }
        public string DocumentRefYear { get; set; }
        public string YourReferenceNumber { get; set; }
        public string AdditionalComments { get; set; }
        public decimal? StampDutyCalculation { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? PaymentDueDate { get; set; }

        public virtual DocumentTypeMaster DocumentType { get; set; }
        public virtual ICollection<PartyPropertyDetailsTransaction> PartyPropertyDetailsTransaction { get; set; }
        public virtual ICollection<PropertyDetailsTransaction> PropertyDetailsTransaction { get; set; }
        public virtual ICollection<VendorTransaction> VendorTransaction { get; set; }
    }
}
