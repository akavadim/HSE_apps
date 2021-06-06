using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskType4.Ganta
{
    class WorkCollection:ICollection<Work>
    {
        List<WorkItem> items;

        public WorkCollection()
        {
            items = new List<WorkItem>();
        }

        public int Count => items.Count;

        public bool IsReadOnly => false;

        /// <summary>
        /// Добавляет элемент в конец коллекции
        /// </summary>
        /// <param name="item"></param>
        public void Add(Work item)
        {
            
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Work item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Work[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Work item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Work> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Work? GetByTime(int time)
        {
            if (time < 0)
                throw new ArgumentOutOfRangeException(nameof(time));
            foreach (var item in items)
                if ((item.StartTime <= time && item.EndTime > time))
                    return item.Work;
            return null;
        }
    }
}
