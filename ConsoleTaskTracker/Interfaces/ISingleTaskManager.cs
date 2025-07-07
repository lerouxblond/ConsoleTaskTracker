using ConsoleTaskTracker.Model;
using ConsoleTaskTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskTracker.Interfaces
{
    public interface ISingleTaskManager
    {
        ITaskItem TaskItem { get; set; }
        ITaskItem Run();
        ITaskItem EditTaskValue(ITaskItem ITaskItem);
        void MarkTaskAsComplete(ITaskItem ITaskItem);
        void MarkTaskAsIncomplete(ITaskItem ITaskItem);
    }
}
