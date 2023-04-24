// ReSharper disable ArrangeObjectCreationWhenTypeEvident

using Moq;

namespace Bogoware.Monads.UnitTests;

public class MaybeAsyncTests
{
	private AnotherValue Function() => new AnotherValue(0);
	private AnotherValue Function(Value value) => new AnotherValue(value.Val);
	private Maybe<AnotherValue> BindFunctionSome() => Some(new AnotherValue(0));
	private Maybe<AnotherValue> BindFunctionSome(Value value) => Some(new AnotherValue(value.Val));
	private Maybe<AnotherValue> BindFunctionNone() => None<AnotherValue>();
	private Maybe<AnotherValue> BindFunctionNone(Value value) => None<AnotherValue>();
	
	private Task<AnotherValue> AsyncFunction() => Task.FromResult(new AnotherValue(0));
	private Task<AnotherValue> AsyncFunction(Value value) => Task.FromResult(new AnotherValue(value.Val));
	private Task<Maybe<AnotherValue>> AsyncBindFunctionSome() => Task.FromResult(Some(new AnotherValue(0)));
	private Task<Maybe<AnotherValue>> AsyncBindFunctionSome(Value value) => Task.FromResult(Some(new AnotherValue(value.Val)));
	private Task<Maybe<AnotherValue>> AsyncBindFunctionNone() => Task.FromResult(None<AnotherValue>());
	private Task<Maybe<AnotherValue>> AsyncBindFunctionNone(Value value) => Task.FromResult(None<AnotherValue>());
	
	[Fact]
	public async Task Async_map_asyncAction_withSome()
	{
		var sut = Some(new Value(0));
		var actual = await sut.Map(() => AsyncFunction());
		actual.IsSome.Should().BeTrue();
	}
	
	[Fact]
	public async Task Async_map_asyncFunction_withSome()
	{
		var sut = Some(new Value(0));
		var actual = await sut.Map(v => AsyncFunction(v));
		actual.IsSome.Should().BeTrue();
	}
	
	[Fact]
	public async Task Async_map_asyncAction_withNone()
	{
		var sut = None<Value>();
		var actual = await sut.Map(() => AsyncFunction());
		actual.IsNone.Should().BeTrue();
	}
	
	[Fact]
	public async Task Async_map_asyncFunction_withNone()
	{
		var sut = None<Value>();
		var actual = await sut.Map(v => AsyncFunction(v));
		actual.IsNone.Should().BeTrue();
	}
	
	[Fact]
	public async Task Async_flatMap_asyncAction_withSome()
	{
		var sut = Some(new Value(0));
		var actual = await sut.Bind(() => AsyncBindFunctionSome());
		actual.IsSome.Should().BeTrue();
	}
	
	[Fact]
	public async Task Async_flatMap_asyncFunction_withSome()
	{
		var sut = Some(new Value(0));
		var actual = await sut.Bind(v => AsyncBindFunctionSome(v));
		actual.IsSome.Should().BeTrue();
	}
	
	[Fact]
	public async Task Async_flatMap_asyncAction_withNone()
	{
		var sut = None<Value>();
		var actual = await sut.Bind(() => AsyncBindFunctionNone());
		actual.IsNone.Should().BeTrue();
	}
	
	[Fact]
	public async Task Async_flatMap_asyncFunction_withNone()
	{
		var sut = None<Value>();
		var actual = await sut.Bind(v => AsyncBindFunctionNone(v));
		actual.IsNone.Should().BeTrue();
	}
	
	[Fact]
	public async Task AsyncExtensions_map_asyncAction_withSome()
	{
		var sut = Task.FromResult(Some(new Value(0)));
		var actual = await sut.Map(() => AsyncFunction());
		actual.IsSome.Should().BeTrue();
	}
	
	[Fact]
	public async Task AsyncExtensions_map_asyncFunction_withSome()
	{
		var sut = Task.FromResult(Some(new Value(0)));
		var actual = await sut.Map(v => AsyncFunction(v));
		actual.IsSome.Should().BeTrue();
	}
	
	[Fact]
	public async Task AsyncExtensions_map_asyncAction_withNone()
	{
		var sut = Task.FromResult(None<Value>());
		var actual = await sut.Map(() => AsyncFunction());
		actual.IsNone.Should().BeTrue();
	}
	
	[Fact]
	public async Task AsyncExtensions_map_asyncFunction_withNone()
	{
		var sut = Task.FromResult(None<Value>());
		var actual = await sut.Map(v => AsyncFunction(v));
		actual.IsNone.Should().BeTrue();
	}
	
	[Fact]
	public async Task AsyncExtensions_flatMap_asyncAction_withSome()
	{
		var sut = Task.FromResult(Some(new Value(0)));
		var actual = await sut.Bind(() => AsyncBindFunctionSome());
		actual.IsSome.Should().BeTrue();
	}
	
	[Fact]
	public async Task AsyncExtensions_flatMap_asyncFunction_withSome()
	{
		var sut = Task.FromResult(Some(new Value(0)));
		var actual = await sut.Bind(v => AsyncBindFunctionSome(v));
		actual.IsSome.Should().BeTrue();
	}
	
	[Fact]
	public async Task AsyncExtensions_map_Action_withSome()
	{
		var sut = Task.FromResult(Some(new Value(0)));
		var actual = await sut.Map(() => Function());
		actual.IsSome.Should().BeTrue();
	}
	
	[Fact]
	public async Task AsyncExtensions_map_Function_withSome()
	{
		var sut = Task.FromResult(Some(new Value(0)));
		var actual = await sut.Map(v => Function(v));
		actual.IsSome.Should().BeTrue();
	}
	
	[Fact]
	public async Task AsyncExtensions_map_Action_withNone()
	{
		var sut = Task.FromResult(None<Value>());
		var actual = await sut.Map(() => Function());
		actual.IsNone.Should().BeTrue();
	}
	
	[Fact]
	public async Task AsyncExtensions_map_Function_withNone()
	{
		var sut = Task.FromResult(None<Value>());
		var actual = await sut.Map(v => Function(v));
		actual.IsNone.Should().BeTrue();
	}
	
	[Fact]
	public async Task AsyncExtensions_flatMap_Action_withSome()
	{
		var sut = Task.FromResult(Some(new Value(0)));
		var actual = await sut.Bind(() => BindFunctionSome());
		actual.IsSome.Should().BeTrue();
	}
	
	[Fact]
	public async Task AsyncExtensions_flatMap_Function_withSome()
	{
		var sut = Task.FromResult(Some(new Value(0)));
		var actual = await sut.Bind(v => BindFunctionSome(v));
		actual.IsSome.Should().BeTrue();
	}
	
	[Fact]
	public async Task Async_wthDefault_value()
	{
		var sut = Task.FromResult(None<Value>());
		var actual = await sut.WithDefault(new Value(1));
		actual.IsSome.Should().BeTrue();
	}
	
	[Fact]
	public async Task Async_wthDefault_function()
	{
		var sut = Task.FromResult(None<Value>());
		var actual = await sut.WithDefault(() => new(1));
		actual.IsSome.Should().BeTrue();
	}
	
	[Fact]
	public async Task Async_wthDefault_asyncFunction()
	{
		var sut = Task.FromResult(None<Value>());
		var actual = await sut.WithDefault(() => Task.FromResult<Value>(new(0)));
		actual.IsSome.Should().BeTrue();
	}

	[Fact]
	public async Task Match_with_values()
	{
		var sut = Task.FromResult(None<Value>());
		var actual = await sut.Match(0, 1);
		actual.Should().Be(1);
	}
	[Fact]
	public async Task Match_with_func_and_value()
	{
		var sut = Task.FromResult(None<Value>());
		var actual = await sut.Match(_ => 0, 1);
		actual.Should().Be(1);
	}
	
	[Fact]
	public async Task Match_with_funcs()
	{
		var sut = Task.FromResult(None<Value>());
		var actual = await sut.Match(_ => 0, () => 1);
		actual.Should().Be(1);
	}
	
	[Fact]
	public async Task Match_with_asyncLeft()
	{
		var sut = Task.FromResult(None<Value>());
		var actual = await sut.Match(_ => Task.FromResult(0), () => 1);
		actual.Should().Be(1);
	}
	[Fact]
	public async Task Match_with_asyncRight()
	{
		var sut = Task.FromResult(None<Value>());
		var actual = await sut.Match(_ => 0, () => Task.FromResult(1));
		actual.Should().Be(1);
	}
	
	[Fact]
	public async Task Match_with_asyncBoth()
	{
		var sut = Task.FromResult(None<Value>());
		var actual = await sut.Match(_ => Task.FromResult(0), () => Task.FromResult(1));
		actual.Should().Be(1);
	}

	[Fact]
	public async Task IfSome_action()
	{
		var inspector = new Mock<ICallInspector>();
		var sut = Task.FromResult(Some(new Value(0)));
		var actual = await sut.ExecuteIfSome(inspector.Object.MethodVoid);
		inspector.Verify(_ => _.MethodVoid());
	}
	
	[Fact]
	public async Task IfSome_action_with_arg()
	{
		var inspector = new Mock<ICallInspector>();
		var sut = Task.FromResult(Some(new Value(0)));
		var actual = await sut.ExecuteIfSome(inspector.Object.MethodWithValueArg);
		inspector.Verify(_ => _.MethodWithValueArg(It.IsAny<Value>()));
	}
	
	[Fact]
	public async Task IfSome_asyncAction()
	{
		var inspector = new Mock<ICallInspector>();
		var sut = Task.FromResult(Some(new Value(0)));
		var actual = await sut.ExecuteIfSome(inspector.Object.MethodVoidAsync);
		inspector.Verify(_ => _.MethodVoidAsync());
	}
	
	[Fact]
	public async Task IfSome_asyncAction_with_arg()
	{
		var inspector = new Mock<ICallInspector>();
		var sut = Task.FromResult(Some(new Value(0)));
		var actual = await sut.ExecuteIfSome(inspector.Object.MethodWithValueArgAsync);
		inspector.Verify(_ => _.MethodWithValueArgAsync(It.IsAny<Value>()));
	}
	
	[Fact]
	public async Task IfNone_action()
	{
		var inspector = new Mock<ICallInspector>();
		var sut = Task.FromResult(None<Value>());
		var actual = await sut.ExecuteIfNone(inspector.Object.MethodVoid);
		inspector.Verify(_ => _.MethodVoid());
	}
	[Fact]
	public async Task IfNone_actionAsync()
	{
		var inspector = new Mock<ICallInspector>();
		var sut = Task.FromResult(None<Value>());
		var actual = await sut.ExecuteIfNone(inspector.Object.MethodVoidAsync);
		inspector.Verify(_ => _.MethodVoidAsync());
	}
	
	[Fact]
	public async Task Tap_action()
	{
		var inspector = new Mock<ICallInspector>();
		var sut = Task.FromResult(None<Value>());
		var actual = await sut.Execute(inspector.Object.MethodWithMaybeArg);
		inspector.Verify(_ => _.MethodWithMaybeArg(It.IsAny<Maybe<Value>>()));
	}
	[Fact]
	public async Task Tap_actionAsync()
	{
		var inspector = new Mock<ICallInspector>();
		var sut = Task.FromResult(None<Value>());
		var actual = await sut.Execute(inspector.Object.MethodWithMaybeArgAsync);
		inspector.Verify(_ => _.MethodWithMaybeArgAsync(It.IsAny<Maybe<Value>>()));
	}
}