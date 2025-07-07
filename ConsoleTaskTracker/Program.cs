using ConsoleTaskTracker.Infrastructure;
using ConsoleTaskTracker.Services;
using System;

var ui = new ConsoleUserInterface();
TaskServices taskServices = new TaskServices(null!, ui).Initialize();
taskServices.Start();