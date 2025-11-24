using FluentAssertions;

namespace Tests;

public class DummyFailing
{
	[Fact]
	private void FailingTest()
	{
		const bool value = true;
		value.Should().BeTrue();
	}
}