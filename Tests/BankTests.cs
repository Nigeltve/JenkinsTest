using JenkinsTest;
using FluentAssertions;

namespace Tests;

public class BankTests
{
    private readonly User user1 = new ("John", "Doe");
    private readonly User user2 = new ("Jane", "Doe");

	[Fact]
    public void MakeAccount_WithNewUser_CreatesAndReturnsNewAccount()
    {
        var bank = new Bank();

        var account = bank.MakeAccount(user1);

        account.Should().NotBeNull();
        account.User.Should().Be(user1);
        bank.Accounts.Should().ContainSingle();
        bank.Accounts.Should().Contain(account);
    }

    [Fact]
    public void MakeAccount_WithExistingUser_ReturnsExistingAccount()
    {
        var bank = new Bank();
        var firstAccount = bank.MakeAccount(user1);
        var secondAccount = bank.MakeAccount(user1);

        secondAccount.Should().BeSameAs(firstAccount);
        bank.Accounts.Should().ContainSingle();
    }

    [Fact]
    public void MakeAccount_WithMultipleDifferentUsers_CreatesMultipleAccounts()
    {
        var bank = new Bank();

        var account1 = bank.MakeAccount(user1);
        var account2 = bank.MakeAccount(user2);

        bank.Accounts.Should().HaveCount(2);
        bank.Accounts.Should().Contain([account1, account2]);
    }

    [Fact]
    public void RemoveAccount_WithExistingUser_RemovesAccountAndReturnsTrue()
    {
        var bank = new Bank();
        bank.MakeAccount(user1);

        var result = bank.RemoveAccount(user1);

        result.Should().BeTrue();
        bank.Accounts.Should().BeEmpty();
    }

    [Fact]
    public void RemoveAccount_WithNonExistentUser_ReturnsFalse()
    {
        var bank = new Bank();

        var result = bank.RemoveAccount(user1);

        result.Should().BeFalse();
        bank.Accounts.Should().BeEmpty();
    }

    [Fact]
    public void RemoveAccount_WithMultipleAccounts_RemovesOnlySpecifiedAccount()
    {
        var bank = new Bank();
        var account1 = bank.MakeAccount(user1);
        var account2 = bank.MakeAccount(user2);

        var result = bank.RemoveAccount(user1);

        result.Should().BeTrue();
        bank.Accounts.Should().ContainSingle();
        bank.Accounts.Should().Contain(account2);
        bank.Accounts.Should().NotContain(account1);
    }

    [Fact]
    public void GetAccount_WithExistingUser_ReturnsAccount()
    {
        var bank = new Bank();
        var expectedAccount = bank.MakeAccount(user1);

        var account = bank.GetAccount(user1);

        account.Should().NotBeNull();
        account.Should().BeSameAs(expectedAccount);
    }

    [Fact]
    public void GetAccount_WithNonExistentUser_ReturnsNull()
    {
        var bank = new Bank();

        var account = bank.GetAccount(user1);

        account.Should().BeNull();
    }

    [Fact]
    public void GetAccount_AfterRemovingAccount_ReturnsNull()
    {
        var bank = new Bank();
        bank.MakeAccount(user1);
        bank.RemoveAccount(user1);

        var account = bank.GetAccount(user1);

        account.Should().BeNull();
    }

    [Fact]
    public void Accounts_InitialState_IsEmptyList()
    {
        var bank = new Bank();

        bank.Accounts.Should().NotBeNull();
        bank.Accounts.Should().BeEmpty();
    }
}