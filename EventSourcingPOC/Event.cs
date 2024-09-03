using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingPOC
{
    public abstract class Event
    {
        public abstract Guid StreamId { get;}
        public DateTime CreatedAtUtc { get; set; }

    }
}
