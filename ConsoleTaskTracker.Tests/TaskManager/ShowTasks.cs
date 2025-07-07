using ConsoleTaskTracker.Infrastructure;
using ConsoleTaskTracker.Managers;
using ConsoleTaskTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskTracker.Tests.TaskManagerTest
{
    public class ShowTasks
    {
        [Fact]
        public void ShowTasks_DisplaysAllTasks()
        {
            var mockUI = new MockUserInterface();
            var taskManager = new TaskManager(mockUI);

            taskManager.TaskList.Add(new TaskItem("Test 1", "Desc 1"));
            taskManager.TaskList.Add(new TaskItem("Test 2", "Desc 2") { IsComplete = true });

            mockUI.AddInput("1");
            mockUI.AddInput("");
            mockUI.AddInput("5");
            mockUI.AddInput("");

            taskManager.Run();
            Assert.DoesNotContain("No tasks found, please create one by pressing '2' in the main menu", mockUI.Output);
        }

        [Fact]
        public void ShowTasks_DisplaysNoTasksMessage()
        {
            var mockUI = new MockUserInterface();
            var taskManager = new TaskManager(mockUI);

            mockUI.AddInput("1");
            mockUI.AddInput("");
            mockUI.AddInput("5");
            mockUI.AddInput("");

            taskManager.Run();

            Assert.Contains("No tasks found, please create one by pressing '2' in the main menu", mockUI.Output);
        }


    }
}
