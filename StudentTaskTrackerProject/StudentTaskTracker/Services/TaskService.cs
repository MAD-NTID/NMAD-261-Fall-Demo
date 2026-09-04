using System.Collections.ObjectModel;
using StudentTaskTracker.Models;

namespace StudentTaskTracker.Services;

public class TaskService
{
    public ObservableCollection<StudentTask> Tasks { get; private set; }

    public TaskService(ObservableCollection<StudentTask> tasks)
    {
        Tasks = tasks;
    }
    
    public void Add(StudentTask task)
    {
        if(task is null)
            throw new ArgumentNullException("Task cannot be null.");
        Tasks.Add(task);
    }

    public StudentTask? Get(StudentTask task)
    {
        return Tasks.FirstOrDefault(search => search.Equals(task));
    }
    
}