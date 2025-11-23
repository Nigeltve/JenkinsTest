namespace JenkinsTest;

public class Bank
{
	public List<Account> Accounts { get; } = [];

	public Account MakeAccount(User user)
	{
		var account = Accounts.FirstOrDefault(a => a.User == user);

		if (account != null) return account;

		var newAccount = new Account(user);
		Accounts.Add(newAccount);
		return newAccount;
	}

	public bool RemoveAccount(User user)
	{
		var account = Accounts.FirstOrDefault(a => a.User == user);

		if (account == null) return false;
		Accounts.Remove(account);

		return true;
	}

	public Account? GetAccount(User user)
	{
		return Accounts.FirstOrDefault(a => a.User == user);
	}
}