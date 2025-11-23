namespace JenkinsTest;

public class User(string name, string email)
{
	public string FirstName { get; private set; } = name;
	public string LastName { get; private set; } = email;

	public override string ToString()
	{
		return $"{FirstName} {LastName}";
	}
}