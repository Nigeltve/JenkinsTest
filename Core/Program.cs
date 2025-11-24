namespace Core
{
	internal abstract class Program
	{
		private static void Main(string[] _)
		{
			var bank = new Bank();

			var account1 = bank.MakeAccount(new User("user1", "user1@Test.com"));
			var account2 = bank.MakeAccount(new User("user2", "user2@Test.com"));

			account1.AddBalance(10);
			account2.AddBalance(100);
		}
	}
}
