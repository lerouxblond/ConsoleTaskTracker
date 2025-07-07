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
    public class TaskManager : ITaskManager
    {
        #region Properties
        public List<ITaskItem> TaskList { get; set; } = [];
        readonly IUserInterface _ui = new ConsoleUserInterface();
        private readonly ViewTaskManager _viewTaskManager;

        public TaskManager(IUserInterface ui) 
        {
            _ui = ui;
            _viewTaskManager = new ViewTaskManager(_ui);
        }

        #endregion

        #region Interface Methods
        public void AddTask(TaskItem taskItem) => TaskList.Add(taskItem);

        public void RemoveTask(TaskItem taskItem) => TaskList.Remove(taskItem);

        public TaskItem ShowSelectedTask(int index) => (TaskItem)TaskList[index];
        #endregion

        #region Main Menu
        public void Run()
        {
            _ui.WriteLine("Welcome to the Task Tracker!");
            MainMenu();
        }

        private void MainMenu()
        {
            while (true)
            {
                _ui.Clear();
                var option = _viewTaskManager.ConsoleView();
                switch (option)
                {
                    case 1:
                        ShowTask();
                        break;
                    case 2:
                        CreateTask();
                        break;
                    case 3:
                        DeleteTask();
                        break;
                    case 4:
                        SelectTask();
                        break;
                    case 5:
                        _ui.WriteLine("Thanks for using 'Console Task Manager', press input to exit...");
                        _ui.ReadLine();
                        return;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region _ui Operation
        private void ShowTask()
        {
            _ui.Clear();
            if(TaskList.Count == 0)
                _ui.WriteLine("No tasks found, please create one by pressing '2' in the main menu");
            else
                _viewTaskManager.ViewAllTasks(TaskList);
            _ui.ReadLine();
        }

        private void CreateTask()
        {
            var newTask = _viewTaskManager.ViewCreateTask();
            TaskList.Add(newTask);
            _ui.WriteLine("Task added succesfully, press a key to go back to main menu...");
            _ui.ReadLine();
        }

        private void DeleteTask()
        {
            
            if (TaskList.Count == 0)
            {

                _ui.Clear();
                _ui.WriteLine("===== Delete Task =====");
                _ui.WriteLine("No task found, please create one by pressing '2' in the main menu");
                _ui.ReadLine();
                
            }
            else
            {
                int index = _viewTaskManager.ViewSelectDeleteTask(TaskList);
                TaskList = _viewTaskManager.ViewDeleteTask(TaskList, index);
            }

        }

        private void SelectTask()
        {
            _ui.Clear();
            if (TaskList.Count == 0)
            {
                _ui.WriteLine("===== Select Task =====");
                _ui.WriteLine("No tasks found. Please create one before by pressing '2'.");
                _ui.ReadLine();
            }
            else
            {
                int index = _viewTaskManager.ViewSelectTask(TaskList);
                var selectedTask = TaskList[index];
                SingleTaskManager singleTaskManager = new(selectedTask, _ui);
                var returnTask = singleTaskManager.Run();
                TaskList.Remove(selectedTask);
                TaskList.Insert(index, returnTask);
            }
        }
        #endregion
    }
}
