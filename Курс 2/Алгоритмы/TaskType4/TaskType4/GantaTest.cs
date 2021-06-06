using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskType4
{
    struct WorkItem
    {
        public string Name;
        public int Duration,
            StartTime;
        public int EndTime { get
            {
                return StartTime + Duration;
            } }
    }

    class GantaTest
    {
        public List<WorkItem> worker1;
        public List<WorkItem> worker2;

        public GantaTest()
        {
            worker1 = new List<WorkItem>();
            worker2 = new List<WorkItem>();
        }

        public override string ToString()
        {
            StringBuilder setka1 = new StringBuilder(RepeatString("|#", worker2.Last().EndTime) + "|"),
                   setka2 = new StringBuilder(setka1.ToString());
            string DownLine = RepeatString("|_", (setka1.Length)/2)+"|",
                    upLine= RepeatString("_", setka1.Length),
                   timeLine = "";

            for (int i = 0; i <= worker2.Last().EndTime; i++)
                timeLine+=i%10 + " ";


            for (int i=0; i<worker1.Count; i++)
            {
                setka1[1 + worker1[i].StartTime * 2] = worker1[i].Name[0];
                for(int j=1; j<worker1[i].Duration; j++)
                {
                    setka1[1 + worker1[i].StartTime * 2 + j * 2] = ' ';
                }
            }

            for (int i = 0; i < worker2.Count; i++)
            {
                setka2[1 + worker2[i].StartTime * 2] = worker2[i].Name[0];
                for (int j = 1; j < worker2[i].Duration; j++)
                {
                    setka2[1 + worker2[i].StartTime * 2 + j * 2] = ' ';
                }
            }

            string res = upLine + "\n" + setka1 + "\n" + DownLine + "\n" + setka2 + "\n" +DownLine+"\n" + timeLine;
            return res;

        }

        public string RepeatString(string str, int count)
        {
            string res = "";
            for (int i = 0; i < count; i++)
                res += str;
            return res;
        }
    }
}
