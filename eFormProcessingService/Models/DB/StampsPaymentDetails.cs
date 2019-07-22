using System;
using System.Collections.Generic;

namespace eFormProcessingService.Models.DB
{
    public partial class StampsPaymentDetails
    {
        public int Id { get; set; }
        public int SalesDutyId { get; set; }
        public decimal? StampDuty { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public string IsPaid { get; set; }
        public string IsActive { get; set; }
    }
}
