using ConsoleTaskTracker.Infrastructure;
using ConsoleTaskTracker.Model;
using ConsoleTaskTracker.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskTracker.Tests.TaskManagerTest
{
    public class DeleteTask
    {
        [Fact]
        public void DeleteTask_TaskDeleteWhenConfirm()
        {
            var mockUI = new MockUserInterface();

            var tasks = new List<ITaskItem>
            {
                new TaskItem("Task 1", "Desc 1"),
                new TaskItem("Task 2", "Desc 2")
            };

            mockUI.AddInput("2");  
            mockUI.AddInput("y");  

            var view = new ViewTaskManager(mockUI);

            int selectedIndex = view.ViewSelectDeleteTask(tasks);
            var updatedTasks = view.viewDeleteTask(tasks, selectedIndex);

            Assert.Single(updatedTasks); 
            Assert.Equal("Task 1", updatedTasks[0].taskName);
        }

        [Fact]
        public void DeleteTask_DeleteCancelledWhenReject()
        {
            var mockUI = new MockUserInterface();

            var tasks = new List<ITaskItem>
            {
                new TaskItem("Task A", "Desc A"),
                new TaskItem("Task B", "Desc B")
            };

            mockUI.AddInput("1");
            mockUI.AddInput("n"); 

            var view = new ViewTaskManager(mockUI);

            int selectedIndex = view.ViewSelectDeleteTask(tasks);
            var updatedTasks = view.viewDeleteTask(tasks, selectedIndex);

            Assert.Equal(2, updatedTasks.Count); 
            Assert.Contains(updatedTasks, t => t.taskName == "Task A");
            Assert.Contains(updatedTasks, t => t.taskName == "Task B");
        }

    }
}
