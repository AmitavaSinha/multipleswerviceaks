using System;
using System.Collections.Generic;

namespace eFormProcessingService.Models.DB
{
    public partial class PropertyLevelUnitTransaction
    {
        public int Id { get; set; }
        public int PropertyDetailsId { get; set; }
        public string IsActive { get; set; }
        public string LevelUnit1 { get; set; }
        public string LevelUnit2 { get; set; }
        public string StreetName { get; set; }

        public virtual PropertyDetailsTransaction PropertyDetails { get; set; }
    }
}
