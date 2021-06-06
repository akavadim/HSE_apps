using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskType4.Ganta
{
    struct WorkItem
    {
        public Work Work;
        public int StartTime;
        public int EndTime;

        public WorkItem(Work Work, int StartTime, int EndTime)
        {
            this.Work = Work;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
        }
    }
}
