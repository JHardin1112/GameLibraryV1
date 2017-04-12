using Microsoft.Practices.Composite.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibraryV1
{
    public class EventAggregator : IEventAggregator
    {
        public TEventType GetEvent<TEventType>() where TEventType : EventBase
        {
            throw new NotImplementedException();
        }
    }
}
