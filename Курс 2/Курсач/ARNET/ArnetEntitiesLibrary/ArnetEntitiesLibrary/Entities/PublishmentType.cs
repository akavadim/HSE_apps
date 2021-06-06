using System;
using System.Collections.Generic;

namespace Arnet.Database
{
    public partial class PublishmentType
    {
        public PublishmentType()
        {
            Publishments = new HashSet<Publishment>();
        }

        public int PublishmentTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Publishment> Publishments { get; set; }
    }
}
