using ConsoleTaskTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskTracker.Interfaces
{
    public interface IViewSingleTaskManager
    {

        int MainMenu(ITaskItem task);

    }
}
