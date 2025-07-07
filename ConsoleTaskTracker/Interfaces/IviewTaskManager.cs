using ConsoleTaskTracker.Model;

namespace ConsoleTaskTracker.Interfaces
{
    public interface IViewTaskManager
    {
        int ConsoleView();
        void ViewAllTasks(List<ITaskItem> tasks);
        TaskItem ViewCreateTask();
        int ViewSelectTask(List<ITaskItem> tasks);
        int ViewSelectDeleteTask(List<ITaskItem> tasks);
        List<ITaskItem> ViewDeleteTask(List<ITaskItem> taskList, int index);
    }
}
