using System;
using System.Collections.Generic;

namespace eFormProcessingService.Models.DB
{
    public partial class PropertyTypeMaster
    {
        public PropertyTypeMaster()
        {
            PropertyDetailsTransaction = new HashSet<PropertyDetailsTransaction>();
        }

        public int Id { get; set; }
        public string PropertyTypeName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<PropertyDetailsTransaction> PropertyDetailsTransaction { get; set; }
    }
}
