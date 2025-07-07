using ConsoleTaskTracker.Model;
using ConsoleTaskTracker.Services;
using ConsoleTaskTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleTaskTracker.View
{
    public class ViewTaskManager(IUserInterface ui) : IViewTaskManager
    {
        #region Properties
        private readonly IUserInterface _ui = ui;

        #endregion

        public int ConsoleView()
        {
            while (true)
            {
                _ui.Clear();
                _ui.WriteLine("===== Task Tracker =====\n");
                _ui.WriteLine("1. View All Tasks");
                _ui.WriteLine("2. Create New Task");
                _ui.WriteLine("3. Delete a Task");
                _ui.WriteLine("4. Select Task");
                _ui.WriteLine("5. Exit");
                _ui.Write("\nEnter your choice: ");
                string input = _ui.ReadLine() ?? string.Empty;

                if (int.TryParse(input, out int option) && option >= 1 && option <= 5)
                {
                    return option;
                }

                _ui.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                _ui.ReadLine();
            }
        }

        public void ViewAllTasks(List<ITaskItem> tasks)
        {
            _ui.WriteLine("Here is all your tasks:");
            foreach (var task in tasks)
            {
                _ui.WriteLine($"\n{tasks.IndexOf(task)+1}. Name: {task.TaskName} | Description: {task.TaskDescription} | Creation date: {task.TaskStartDate} | Status: {task}");
            }
        }

        public TaskItem ViewCreateTask()
        {
            string name;
            do
            {
                _ui.Clear();
                _ui.WriteLine("===== Create a task =====\n");
                _ui.Write("Enter a task name (Mandatory): ");
                name = _ui.ReadLine() ?? string.Empty;
            } while (string.IsNullOrWhiteSpace(name));

            _ui.Write("Enter a description of your task (Optional): ");
            string description = _ui.ReadLine() ?? string.Empty;

            return new TaskItem(name, description);
        }


        #region Delete View Methods
        public List<ITaskItem> ViewDeleteTask(List<ITaskItem> taskList, int index)
        {
            while (true)
            {
            _ui.Clear();
            _ui.WriteLine("===== Delete Task =====");
                _ui.Write($"\nAre you sure you want to delete task: {taskList[index].TaskName}? Y / N: ");
                var response = _ui.ReadLine() ?? string.Empty;

                switch (response.ToLower())
                {
                    case "y":
                        taskList.RemoveAt(index);
                        return taskList;

                    case "n":
                        return taskList;

                    default:
                        _ui.WriteLine("Invalid input. Please enter Y or N.");
                        _ui.ReadLine();
                        break;
                }
            }
        }

        public int ViewSelectDeleteTask(List<ITaskItem> tasks)
        {
            while (true)
            {
                _ui.Clear();
                _ui.WriteLine("===== Delete Task =====");
                _ui.Write("\nChoose the index of the task you want to delete: ");
                var response = _ui.ReadLine() ?? string.Empty;

                if (int.TryParse(response, out int index) && index > 0 && index <= tasks.Count)
                {
                    return index - 1;
                }

                _ui.WriteLine("Invalid input. Please enter a valid task number.");
                _ui.ReadLine();
            }
        }
        #endregion

        #region TaskSelection Methods


        public int ViewSelectTask(List<ITaskItem> tasks)
        {
            while(true)
            {
                _ui.Clear();
                _ui.WriteLine("===== Select Task =====");
                _ui.WriteLine("Choose the index of the task you want to select: ");
                var response = _ui.ReadLine() ?? string.Empty;
                if(int.TryParse(response, out int index) && index > 0 && index <= tasks.Count)
                {
                    return index - 1;
                }
                _ui.WriteLine("Invalid Input. Please enter a valid task number.");
                _ui.ReadLine();
            }
        }
        #endregion
    }
}
