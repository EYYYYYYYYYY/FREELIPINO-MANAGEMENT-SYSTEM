
public class Freelancer
{
	public int FreelancerId { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public List<Project> Projects { get; set; }
}

// Models/Project.cs
public class Project
{
	public int ProjectId { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public int FreelancerId { get; set; }
	public Freelancer Freelancer { get; set; }
	public List<Activity> Activities { get; set; }
}

// Models/Activity.cs
public class Activity
{
	public int ActivityId { get; set; }
	public int ProjectId { get; set; }
	public Project Project { get; set; }
	public string Description { get; set; }
	public DateTime Date { get; set; }
	public double HoursSpent { get; set; }
}
