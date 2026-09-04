using System.Collections.ObjectModel;
using StudentTaskTracker;
using StudentTaskTracker.Models;
using StudentTaskTracker.Services;

namespace Test.Service;


public class TaskServiceTest
{
    [Fact]
    public void TestAdd()
    {
        //setup
        TaskService taskService = new TaskService(new ObservableCollection<StudentTask>());
        int expectedTaskCount = 1;
        
        StudentTask task = new StudentTask()
            { Name = "Complete Homework", Description = "example description", IsCompleted = false };
        
        //invoke
        taskService.Add(task);
        
        //assert
        Assert.Equal(expectedTaskCount, taskService.Tasks.Count);
    }
}