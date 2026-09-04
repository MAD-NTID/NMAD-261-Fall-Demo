namespace StudentTaskTracker.Models;

public class StudentTask
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted{ get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is not StudentTask)
            return false;
        StudentTask other = (StudentTask)obj;
        
        return other.IsCompleted  == IsCompleted &&
               other.Name == Name &&
               other.Description == Description;
    }
}