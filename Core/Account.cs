namespace Core;

public class Account(User user)
{
	public User User { get; } = user;
	public float Balance { get; private set; } = 0;
	public Guid Id { get; private set; } = Guid.NewGuid();

	public void AddBalance(float amount)
	{
		Balance += amount;
	}

	public void RemoveBalance(float amount)
	{
		Balance -= amount;
	}

	public float GetBalance()
	{
		return Balance;
	}
}