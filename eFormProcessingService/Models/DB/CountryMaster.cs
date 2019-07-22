using System;
using System.Collections.Generic;

namespace eFormProcessingService.Models.DB
{
    public partial class CountryMaster
    {
        public CountryMaster()
        {
            PartyPropertyDetailsTransaction = new HashSet<PartyPropertyDetailsTransaction>();
        }

        public int Id { get; set; }
        public string CountryName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<PartyPropertyDetailsTransaction> PartyPropertyDetailsTransaction { get; set; }
    }
}
