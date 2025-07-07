using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskTracker.Model
{
    public interface ITaskItem
    {
        #region Properties
        string TaskName { get; }
        string TaskDescription { get; }

        DateTime TaskStartDate { get; }
        DateTime TaskEndDate { get; }

        bool IsComplete {  get; }
        #endregion

        #region Universal Task Methods
        void MarkasComplete();
        void MarkasIncomplete();

        string ToString();
        #endregion
    }
}
