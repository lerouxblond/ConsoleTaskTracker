using ConsoleTaskTracker.Infrastructure;
using ConsoleTaskTracker.Interfaces;
using ConsoleTaskTracker.Model;
using ConsoleTaskTracker.Services;
using ConsoleTaskTracker.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskTracker.Managers
{
    public class MockTaskManager : ITaskManager
    {

        #region Properties
        public List<TaskItem> TaskList { get; set; } = [];
        private readonly ViewTaskManager _viewTaskManager = new(new MockUserInterface());
        public bool RunCalled { get; private set; } = false;

        
        #endregion

        #region Interfaces

        public void AddTask(TaskItem taskItem) => TaskList.Add(taskItem);

        public static void MarkTaskAsComplete(TaskItem taskItem) => taskItem.MarkasComplete();

        public static void MarkTaskAsIncomplete(TaskItem taskItem) => taskItem.MarkasIncomplete();

        public void RemoveTask(TaskItem taskItem) => TaskList.Remove(taskItem);

        public TaskItem ShowSelectedTask(int index) => TaskList[index];

        public void Run()
        {
            RunCalled = true;
            Console.WriteLine("Mock Run() called");
        }
        #endregion

        public void CreateTask()
        {
            var task = _viewTaskManager.ViewCreateTask();
            AddTask(task);
        }


    }
}

    