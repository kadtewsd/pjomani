using PJOResourceMgmt.Mgmts.Model;
using System.Collections.Generic;

namespace PJOMgmt.Util
{
    public class EventResult<T>
    {
        public EventResult()
        {
            Results = new List<T>();
        }
        public T Result { get; set; }

        public IList<T> Results { get; set; }

        public object ForResearch { get; set; }
    }
}
