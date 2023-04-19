namespace Bogoware.Monads.UnitTests;

public class MaybeWithDefaultTests
{
	[Fact]
	public void WithDefault_value()
	{
		var none = None<string>();
		var some = none.WithDefault("Some");
		some.IsSome.Should().BeTrue();
		some.GetValue("").Should().Be("Some");
	}
	
	[Fact]
	public void WithDefault_function()
	{
		var none = None<string>();
		var some = none.WithDefault(() => "Some");
		some.IsSome.Should().BeTrue();
		some.GetValue("").Should().Be("Some");
	}
	
	[Fact]
	public async Task WithDefault_asyncFunction()
	{
		var none = None<string>();
		var some = await none.WithDefault(() => Task.FromResult("Some"));
		some.IsSome.Should().BeTrue();
		some.GetValue("").Should().Be("Some");
	}
}