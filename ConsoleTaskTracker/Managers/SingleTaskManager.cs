using ConsoleTaskTracker.Infrastructure;
using ConsoleTaskTracker.Interfaces;
using ConsoleTaskTracker.Model;
using ConsoleTaskTracker.Services;
using ConsoleTaskTracker.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskTracker.Managers
{
    public class SingleTaskManager(ITaskItem task, IUserInterface ui) : ISingleTaskManager
    {
        public ITaskItem TaskItem { get; set; } = task;
        readonly IUserInterface _ui = ui; 
        private readonly ViewSingleTaskManager _singleViewTaskManager = new(ui);

        public ITaskItem Run()
        {
            while (true)
            {
                _ui.Clear();
                var option = _singleViewTaskManager.MainMenu(TaskItem);
                switch (option)
                {
                    case 1:
                        SwitchTaskStatus(TaskItem);
                        break;
                    case 2:
                        EditTask();
                        break;
                    case 3:
                        AddSubTask();
                        break;
                    case 4:
                        DeleteSubTask();
                        break;
                    case 5:
                        SwitchSubTaskStatus();
                        break;
                    case 6:
                        return TaskItem;
                    default:
                        break;
                }
            }
            
        }

        #region Main Menu Methods
        private void EditTask()
        {
            TaskItem editTask = _singleViewTaskManager.ViewEditTask(TaskItem);
            TaskItem = EditTaskValue(editTask);
            _ui.WriteLine("Task updated successfully. Press any key to return...");
            _ui.ReadLine();
        }


        private void SwitchTaskStatus(ITaskItem taskItem)
        {

            if (taskItem.IsComplete)
                MarkTaskAsIncomplete(taskItem);
            else
                MarkTaskAsComplete(taskItem);
        }

            #region SubTask Methods
        private void SwitchSubTaskStatus()
        {
            if (TaskItem is TaskItem task)
            {
                if(task.SubTaskList.Count == 0)
                {
                    _ui.WriteLine("No subtask found.");
                    _ui.ReadLine();
                }
                else
                {

                        var index = _singleViewTaskManager.ViewSelectTask(task.SubTaskList);
                    if (task.SubTaskList[index].IsComplete)
                        task.SubTaskList[index].MarkasIncomplete();
                    else
                        task.SubTaskList[index].MarkasComplete();
                }
            }
        }

        private void DeleteSubTask()
        {
            if(TaskItem is TaskItem task)
            {
                
                if (task.SubTaskList.Count == 0)
                {

                    _ui.Clear();
                    _ui.WriteLine("===== Delete Task =====");
                    _ui.WriteLine("No task found, please create one by pressing '2' in the main menu");
                    _ui.ReadLine();

                }
                else
                {
                    int index = _singleViewTaskManager.ViewSelectDeleteSubTask(task.SubTaskList);
                    task.SubTaskList = _singleViewTaskManager.ViewDeleteSubTask(task.SubTaskList, index);
                }
            }
        }

        private void AddSubTask()
        {
            SubTaskItem newSubTask = _singleViewTaskManager.ViewCreateSubTask(TaskItem);
            if (TaskItem is TaskItem task)
                task.AddSubTask(newSubTask);
        }

            #endregion

        #endregion


        #region Interfaces Implementations
        public ITaskItem EditTaskValue(ITaskItem editTask) => editTask;


        public void MarkTaskAsComplete(ITaskItem taskItem) => taskItem.MarkasComplete();
        public void MarkTaskAsIncomplete(ITaskItem taskItem) => taskItem.MarkasIncomplete();
        #endregion
    }
}
