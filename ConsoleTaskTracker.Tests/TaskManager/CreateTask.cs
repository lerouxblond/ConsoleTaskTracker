using ConsoleTaskTracker.Infrastructure;
using ConsoleTaskTracker.Managers;
using ConsoleTaskTracker.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskTracker.Tests.TaskManagerTest
{
    public class CreateTask
    {

        [Fact]
        public void CreateTask_EmptyOrWhitespaceName()
        {
            var mockUI = new MockUserInterface();
            var TM = new TaskManager(mockUI);

            //empty name
            mockUI.AddInput("2");
            mockUI.AddInput("");
            mockUI.AddInput(" ");
            mockUI.AddInput("Valid name");
            mockUI.AddInput("Description");
            mockUI.AddInput(" ");
            mockUI.AddInput("5");
            mockUI.AddInput(" ");


            TM.Run();

            Assert.Single(TM.TaskList);
            var task = TM.TaskList[0];
            Assert.Equal("Valid name", task.TaskName);
        }

        [Fact]
        public void CreateTask_Valid()
        {
            var mockUI = new MockUserInterface();
            var TM = new TaskManager(mockUI);

            //empty name
            mockUI.AddInput("2");
            mockUI.AddInput("Valid name");
            mockUI.AddInput("Description");
            mockUI.AddInput(" ");
            mockUI.AddInput("5");
            mockUI.AddInput(" ");


            TM.Run();

            Assert.Single(TM.TaskList);
            var task = TM.TaskList.First();
            Assert.Equal("Valid name", task.TaskName);
            Assert.Equal("Description", task.TaskDescription);
        }

        [Fact]
        public void CreateTask_NoDesc()
        {
            var mockUI = new MockUserInterface();
            var TM = new TaskManager(mockUI);

            //empty name
            mockUI.AddInput("2");
            mockUI.AddInput("Valid name");
            mockUI.AddInput("");
            mockUI.AddInput(" ");
            mockUI.AddInput("5");
            mockUI.AddInput(" ");


            TM.Run();

            Assert.Single(TM.TaskList);
            var task = TM.TaskList.First();
            Assert.Equal("", task.TaskDescription);
        }
    }
}
