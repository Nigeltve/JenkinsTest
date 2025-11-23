using FluentAssertions;

namespace JenkinsTest.Tests;

public class AccountTests
{
    private readonly User user1 = new User("John", "Doe");
    private readonly User user2 = new User("John", "Doe");

    [Fact]
    public void Constructor_WithUser_SetsUserProperty()
    {
        var account = new Account(user1);
        account.User.Should().Be(user1);
    }

    [Fact]
    public void Constructor_InitializesBalanceToZero()
    {
        var account = new Account(user1);
        account.Balance.Should().Be(0f);
    }

    [Fact]
    public void Constructor_GeneratesUniqueId()
    {
        var account = new Account(user1);
        account.Id.Should().NotBeEmpty();
    }

    [Fact]
    public void Constructor_GeneratesDifferentIdsForDifferentAccounts()
    {

        var account1 = new Account(user1);
        var account2 = new Account(user2);

        account1.Id.Should().NotBe(account2.Id);
    }

    [Fact]
    public void AddBalance_WithPositiveAmount_IncreasesBalance()
    {

        var account = new Account(user1);
        account.AddBalance(100f);
        account.Balance.Should().Be(100f);
    }

    [Fact]
    public void AddBalance_MultipleDeposits_AccumulatesBalance()
    {
        var account = new Account(user1);

        account.AddBalance(50f);
        account.AddBalance(30f);
        account.AddBalance(20f);

        account.Balance.Should().Be(100f);
    }

    [Fact]
    public void AddBalance_WithDecimalAmount_HandlesCorrectly()
    {
        var account = new Account(user1);

        account.AddBalance(10.5f);
        account.AddBalance(20.25f);

        account.Balance.Should().BeApproximately(30.75f, 0.01f);
    }

    [Fact]
    public void AddBalance_WithZero_DoesNotChangeBalance()
    {
        var account = new Account(user1);
        account.AddBalance(100f);
        account.AddBalance(0f);
        account.Balance.Should().Be(100f);
    }

    [Fact]
    public void AddBalance_WithNegativeAmount_DecreasesBalance()
    {
        var account = new Account(user1);
        account.AddBalance(100f);
        account.AddBalance(-30f);

        account.Balance.Should().Be(70f);
    }

    [Fact]
    public void RemoveBalance_WithPositiveAmount_DecreasesBalance()
    {
        var account = new Account(user1);
        account.AddBalance(100f);
        account.RemoveBalance(30f);

        account.Balance.Should().Be(70f);
    }

    [Fact]
    public void RemoveBalance_MultipleWithdrawals_ReducesBalance()
    {
        var account = new Account(user1);
        account.AddBalance(100f);

        account.RemoveBalance(20f);
        account.RemoveBalance(30f);
        account.RemoveBalance(10f);

        account.Balance.Should().Be(40f);
    }

    [Fact]
    public void RemoveBalance_WithDecimalAmount_HandlesCorrectly()
    {
        var account = new Account(user1);
        account.AddBalance(100f);
        account.RemoveBalance(25.5f);

        account.Balance.Should().BeApproximately(74.5f, 0.01f);
    }

    [Fact]
    public void RemoveBalance_WithZero_DoesNotChangeBalance()
    {
        var account = new Account(user1);
        account.AddBalance(100f);
        account.RemoveBalance(0f);

        account.Balance.Should().Be(100f);
    }

    [Fact]
    public void RemoveBalance_MoreThanBalance_AllowsNegativeBalance()
    {
        var account = new Account(user1);
        account.AddBalance(50f);
        account.RemoveBalance(75f);

        account.Balance.Should().Be(-25f);
    }

    [Fact]
    public void RemoveBalance_WithNegativeAmount_IncreasesBalance()
    {
        var account = new Account(user1);
        account.AddBalance(100f);
        account.RemoveBalance(-25f);

        account.Balance.Should().Be(125f);
    }

    [Fact]
    public void GetBalance_ReturnsCurrentBalance()
    {
        var account = new Account(user1);
        account.AddBalance(150f);
        var balance = account.GetBalance();

        balance.Should().Be(150f);
    }

    [Fact]
    public void GetBalance_AfterMultipleOperations_ReturnsCorrectBalance()
    {
        var account = new Account(user1);
        account.AddBalance(100f);
        account.RemoveBalance(30f);
        account.AddBalance(50f);
        account.RemoveBalance(20f);

        var balance = account.GetBalance();
        balance.Should().Be(100f);
    }

    [Fact]
    public void GetBalance_ForNewAccount_ReturnsZero()
    {
        var account = new Account(user1);
        var balance = account.GetBalance();

        balance.Should().Be(0f);
    }

    [Fact]
    public void Balance_Property_ReflectsGetBalanceValue()
    {
        var account = new Account(user1);
        account.AddBalance(75.5f);

        account.Balance.Should().Be(account.GetBalance());
    }

    [Fact]
    public void AddAndRemoveBalance_LargeAmounts_HandlesCorrectly()
    {
        var account = new Account(user1);

        account.AddBalance(1000000f);
        account.RemoveBalance(500000f);
        account.AddBalance(250000f);

        account.Balance.Should().Be(750000f);
    }
}