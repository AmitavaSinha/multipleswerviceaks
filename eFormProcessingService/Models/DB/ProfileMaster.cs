using System;
using System.Collections.Generic;

namespace eFormProcessingService.Models.DB
{
    public partial class ProfileMaster
    {
        public ProfileMaster()
        {
            PartyPropertyDetailsTransaction = new HashSet<PartyPropertyDetailsTransaction>();
        }

        public int Id { get; set; }
        public string ProfileName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<PartyPropertyDetailsTransaction> PartyPropertyDetailsTransaction { get; set; }
    }
}
