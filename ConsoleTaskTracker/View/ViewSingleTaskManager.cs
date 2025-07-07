using ConsoleTaskTracker.Interfaces;
using ConsoleTaskTracker.Model;
using ConsoleTaskTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskTracker.View
{
    public class ViewSingleTaskManager(IUserInterface ui) : IViewSingleTaskManager
    {
        #region Properties
        private readonly IUserInterface _ui = ui;

        #endregion

        #region MainMenu Methods

        public int MainMenu(ITaskItem task)
        {
            while (true)
            {
                _ui.Clear();
                if (task is not TaskItem taskItem)
                    return -1;
                _ui.WriteLine("===== Selected Task =====\n");
                _ui.WriteLine($"NAME: {taskItem?.TaskName} | STATUS: {taskItem}\n");
                _ui.WriteLine($"CREATION DATE: {taskItem?.TaskStartDate}");
                _ui.WriteLine($"END DATE: {(taskItem.IsComplete ? taskItem?.TaskEndDate : "Not finished yet.")}");
                _ui.WriteLine($"\nDESCRIPTION: {taskItem?.TaskDescription}");
                _ui.WriteLine($"\nSUBTASK LIST: \n{DisplayAllSubTask(taskItem?.SubTaskList)}");
                
                _ui.WriteLine("\n1. Toggle Status \n2. Edit Task \n3. Add Subtask \n4. Delete Subtask \n5. Complete Subtask \n6. Back to menu");
                _ui.Write("Choose your option: ");
                var response = _ui.ReadLine() ?? string.Empty;
                if (int.TryParse(response, out int option) && option >= 1 && option <= 6)
                {
                    return option;
                }
                 
                _ui.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                _ui.ReadLine();
            }
        }

        private static string DisplayAllSubTask(List<ITaskItem>? subTaskList)
        {
            if (subTaskList == null || subTaskList.Count == 0)
                return "No subtasks.";

            var sb = new StringBuilder();

            for (int i = 0; i < subTaskList.Count; i++)
            {
                var item = subTaskList[i];
                sb.AppendLine($"[{i + 1}] NAME: {item.TaskName} | DESCRIPTION: {item.TaskDescription} | STATUS: {item}");
            }

            return sb.ToString();
        }
        #endregion

        public TaskItem ViewEditTask(ITaskItem task)
        {
            
            
            _ui.Clear();
            _ui.WriteLine("===== Edit Task =====");

            _ui.Write($"Enter a new name (Leave empty to keep '{task.TaskName}'): ");
            string newName = _ui.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(newName))
                newName = task.TaskName;


            _ui.Write($"Enter a new description (Leave empty to keep current one): ");
            var newDesc = _ui.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(newDesc))
                newDesc = task.TaskDescription;
            return new TaskItem(newName, newDesc);
        }

        public int ViewSelectTask(List<ITaskItem> tasks)
        {
            while (true)
            {
                _ui.Clear();
                _ui.WriteLine("===== Switch Status Selection =====");
                _ui.WriteLine("Choose the index of the subtask you want to switch status: ");
                var response = _ui.ReadLine() ?? string.Empty;
                if (int.TryParse(response, out int index) && index > 0 && index <= tasks.Count)
                {
                    return index - 1;
                }
                _ui.WriteLine("Invalid Input. Please enter a valid subtask number.");
                _ui.ReadLine();
            }
        }

        public SubTaskItem ViewCreateSubTask(ITaskItem task)
        {
            string name;
            do
            {
                _ui.Clear();
                _ui.WriteLine("===== Create a task =====\n");
                _ui.Write("Enter a subtask name (Mandatory): ");
                name = _ui.ReadLine() ?? string.Empty;
            } while (string.IsNullOrWhiteSpace(name));

            _ui.Write("Enter a description of your subtask (Optional): ");
            string description = _ui.ReadLine() ?? string.Empty;

            return new SubTaskItem(name, description, (TaskItem)task);
        }

        public List<ITaskItem> ViewDeleteSubTask(List<ITaskItem> subtaskList, int index)
        {
            while (true)
            {
                _ui.Clear();
                _ui.WriteLine("===== Delete SubTask =====");
                _ui.Write($"\nAre you sure you want to delete subtask: {subtaskList[index].TaskName}? Y / N: ");
                var response = _ui.ReadLine() ?? string.Empty;

                switch (response.ToLower())
                {
                    case "y":
                        subtaskList.RemoveAt(index);
                        return subtaskList;

                    case "n":
                        return subtaskList;

                    default:
                        _ui.WriteLine("Invalid input. Please enter Y or N.");
                        _ui.ReadLine();
                        break;
                }
            }
        }

        public int ViewSelectDeleteSubTask(List<ITaskItem> subtasks)
        {
            while (true)
            {
                _ui.Clear();
                _ui.WriteLine("===== Delete Task =====");
                _ui.Write("\nChoose the index of the subtask you want to delete: ");
                var response = _ui.ReadLine() ?? string.Empty;

                if (int.TryParse(response, out int index) && index > 0 && index <= subtasks.Count)
                {
                    return index - 1;
                }

                _ui.WriteLine("Invalid input. Please enter a valid task number.");
                _ui.ReadLine();
            }
        }
    }
}
