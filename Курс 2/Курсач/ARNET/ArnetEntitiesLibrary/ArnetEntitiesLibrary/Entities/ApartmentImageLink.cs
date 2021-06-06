using System;
using System.Collections.Generic;

namespace Arnet.Database
{
    public partial class ApartmentImageLink
    {
        public int ApartmentImageId { get; set; }
        public int ApartmentId { get; set; }
        public int ImageId { get; set; }

        public virtual Apartment Apartment { get; set; }
        public virtual Image Image { get; set; }
    }
}
