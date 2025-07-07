using ConsoleTaskTracker.Infrastructure;
using ConsoleTaskTracker.Managers;
using ConsoleTaskTracker.Services;
using ConsoleTaskTracker.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskTracker.Tests
{
    
    public class TaskServicesTests
    {
        [Fact]
        public void Start_CallsTaskManagerRun()
        {
            var mockTM = new MockTaskManager();
            var service = new TaskServices(mockTM, new MockUserInterface());

            service.Start();

            Assert.True(mockTM.RunCalled);
        }
    }
}
