using System;
using System.Collections.Generic;

namespace eFormProcessingService.Models.DB
{
    public partial class PostalCodeMaster
    {
        public PostalCodeMaster()
        {
            PartyPropertyDetailsTransaction = new HashSet<PartyPropertyDetailsTransaction>();
            PropertyDetailsTransaction = new HashSet<PropertyDetailsTransaction>();
        }

        public int Id { get; set; }
        public string PostalCode { get; set; }
        public string Blk { get; set; }
        public string Street { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<PartyPropertyDetailsTransaction> PartyPropertyDetailsTransaction { get; set; }
        public virtual ICollection<PropertyDetailsTransaction> PropertyDetailsTransaction { get; set; }
    }
}
