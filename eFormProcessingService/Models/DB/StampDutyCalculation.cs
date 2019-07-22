using System;
using System.Collections.Generic;

namespace eFormProcessingService.Models.DB
{
    public partial class StampDutyCalculation
    {
        public int Id { get; set; }
        public decimal? MinSlab { get; set; }
        public decimal? MaxSlab { get; set; }
        public string Percentage { get; set; }
    }
}
