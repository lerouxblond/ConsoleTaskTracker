using ConsoleTaskTracker.Infrastructure;
using ConsoleTaskTracker.Managers;
using ConsoleTaskTracker.Model;
using ConsoleTaskTracker.View;

namespace ConsoleTaskTracker.Tests
{
    public class TaskManagerTests
    {
        [Fact]
        public void AddTask_IncreaseTaskCount()
        {
            var mockUI = new MockUserInterface();
            mockUI.AddInput("2");

            var view = new ViewTaskManager(mockUI);

            int result = view.ConsoleView();
            Console.WriteLine($"Int output: {result}");
            Assert.Equal(2, result);
        }
    }
}
