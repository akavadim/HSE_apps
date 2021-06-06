using System;
using System.Collections.Generic;

namespace Arnet.Database
{
    public partial class Image
    {
        public Image()
        {
            ApartmentImageLinks = new HashSet<ApartmentImageLink>();
        }

        public int ImageId { get; set; }
        public byte[] Value { get; set; }
        public DateTime DateFrom { get; set; }

        public virtual Account Accounts { get; set; }
        public virtual ICollection<ApartmentImageLink> ApartmentImageLinks { get; set; }
    }
}
