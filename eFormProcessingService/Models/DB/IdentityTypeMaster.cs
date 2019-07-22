using System;
using System.Collections.Generic;

namespace eFormProcessingService.Models.DB
{
    public partial class IdentityTypeMaster
    {
        public IdentityTypeMaster()
        {
            PartyPropertyDetailsTransaction = new HashSet<PartyPropertyDetailsTransaction>();
            VendorTransaction = new HashSet<VendorTransaction>();
        }

        public int Id { get; set; }
        public string IdentityTypeName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<PartyPropertyDetailsTransaction> PartyPropertyDetailsTransaction { get; set; }
        public virtual ICollection<VendorTransaction> VendorTransaction { get; set; }
    }
}
