using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTaskTracker.Model;

namespace ConsoleTaskTracker.Interfaces
{
    public interface ITaskManager
    {
        void AddTask(TaskItem taskItem);
        void RemoveTask(TaskItem taskItem);
        TaskItem ShowSelectedTask(int index);
        void Run();
    }
}
