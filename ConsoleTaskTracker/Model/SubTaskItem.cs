using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskTracker.Model
{
    public class SubTaskItem(string name, string description, TaskItem parentTask) : ITaskItem
    {
        #region Properties
        public string TaskName { get; set; } = name;
        public string TaskDescription { get; set; } = description;

        public DateTime TaskStartDate { get; set; } = DateTime.Now;
        public DateTime TaskEndDate { get; set; }

        public bool IsComplete { get; set; }

        public ITaskItem? ParentTask { get; set; } = parentTask;

        #endregion

        #region Methods
        public void MarkasComplete()
        {
            IsComplete = true;
            TaskEndDate = DateTime.Now;
        }
        public void MarkasIncomplete()
        {
            IsComplete = false;
            TaskEndDate = DateTime.MinValue;
        }

        public override string ToString() => IsComplete ? "[X]" : "[ ]";
        #endregion
    }
}
