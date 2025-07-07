using ConsoleTaskTracker.Interfaces;
using ConsoleTaskTracker.Managers;

namespace ConsoleTaskTracker.Services
{
    public class TaskServices(ITaskManager taskManager, IUserInterface ui)
    {
        private readonly ITaskManager _taskManager = taskManager;
        private readonly IUserInterface _ui = ui;

        public void Start()
        {
            _taskManager.Run();
        }

        public TaskServices Initialize()
        {
            while (true)
            {
                _ui.Clear();
                _ui.WriteLine("Welcome to _ui TaskManager, to begin choose a TM version");
                _ui.WriteLine("\n1. Standard TM \n2. Mock TM (Test only)");
                _ui.Write("\nChoose your TM: ");
                var response = _ui.ReadLine() ?? string.Empty;

                if (int.TryParse(response, out var option))
                {
                    switch (option)
                    {
                        case 1: return new TaskServices(new TaskManager(_ui), _ui);
                        case 2: return new TaskServices(new MockTaskManager(), _ui);
                        default: break;
                    }
                }

                _ui.WriteLine("Invalid Input. Please enter 1 or 2.\n");
            }
        }
    }
}
