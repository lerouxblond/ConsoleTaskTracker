using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskTracker.Model
{
    public class TaskItem(string name, string description) : ITaskItem
    {
        #region Properties
        public string TaskName { get; set; } = name;
        public string TaskDescription { get; set; } = description;

        public DateTime TaskStartDate { get; set; } = DateTime.Now;
        public DateTime TaskEndDate { get; set; }

        public bool IsComplete { get; set; }

        public List<ITaskItem> SubTaskList { get; set; } = [];

        public User? UserLinked { get; set; }

        #endregion

        #region Task Methods
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

        public static User ConnectTaskToUser(User user) => user;

        #endregion

        #region Subtask Methods
        public void AddSubTask(ITaskItem subTask)
        {
            SubTaskList.Add(subTask);
        }
        public void RemoveSubTask(ITaskItem subTask)
        {
            SubTaskList.Remove(subTask);
        }
        #endregion
    }
}
