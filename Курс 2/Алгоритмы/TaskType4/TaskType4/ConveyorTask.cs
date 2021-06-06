using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskType4
{
    struct TaskItem
    {
        public string Name;
        public int DurationPartOne,
                    DurationPartTwo;
        public TaskItem(string Name ,int PartOne, int PartTwo)
        {
            this.Name = Name;
            DurationPartOne = PartOne;
            DurationPartTwo = PartTwo;
        }
    }

    static class ConveyorTask
    {
        public static GantaTest GetPlan(List<TaskItem> tasks)
        {
            if (tasks == null)
                throw new ArgumentNullException(nameof(tasks));
            List<TaskItem> ordered = new List<TaskItem>();
            ordered.Add(tasks[0]);
            for(int i=1; i<tasks.Count; i++)
            {
                for (int j = 0; j < ordered.Count; j++)
                {
                    if (Math.Min(ordered[j].DurationPartOne, tasks[i].DurationPartTwo) > Math.Min(tasks[i].DurationPartOne, ordered[j].DurationPartTwo))
                    {
                        ordered.Insert(j, tasks[i]);
                        break;
                    }
                    else if (ordered.Count - 1 == j)
                    {
                        ordered.Add(tasks[i]);
                        break;
                    }
                }
            }

            int startTimeWorker1 = 0,
                startTimeWorker2 = 0;
            GantaTest ganta = new GantaTest();
            for(int i=0; i<ordered.Count; i++)
            {
                WorkItem workItem1 = new WorkItem() {
                    StartTime = startTimeWorker1,
                    Duration = ordered[i].DurationPartOne,
                    Name = ordered[i].Name + "1"
                };
                startTimeWorker1 = workItem1.EndTime;
                ganta.worker1.Add(workItem1);
                WorkItem workItem2 = new WorkItem()
                {
                    Duration = ordered[i].DurationPartTwo,
                    StartTime = (startTimeWorker2 > workItem1.EndTime) ? startTimeWorker2 : workItem1.EndTime,
                    Name = ordered[i].Name + "2"
                };
                startTimeWorker2 = workItem2.EndTime;
                ganta.worker2.Add(workItem2);
            }
            return ganta;
        }

    }
}
