using System.Runtime.CompilerServices;

namespace Bogoware.Monads;

public static class OptionalAsyncExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<Optional<TResult>> Map<T, TResult>(this Task<Optional<T>> optionalTask, Func<TResult> map)
		where TResult : class
		where T : class
		=> (await optionalTask).Map(map);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<Optional<TResult>> Map<T, TResult>(
		this Task<Optional<T>> optionalTask, Func<T, TResult> map)
		where TResult : class
		where T : class
		=> (await optionalTask).Map(map);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<Optional<TResult>> Map<T, TResult>(
		this Task<Optional<T>> optionalTask, Func<Task<TResult>> map)
		where TResult : class
		where T : class
		=> await (await optionalTask).Map(map);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<Optional<TResult>> Map<T, TResult>(
		this Task<Optional<T>> optionalTask, Func<T, Task<TResult>> map)
		where TResult : class
		where T : class
		=> await (await optionalTask).Map(map);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<Optional<T>> WithDefault<T>(
		this Task<Optional<T>> optionalTask,
		T value) where T : class
		=> (await optionalTask).WithDefault(value);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<Optional<T>> WithDefault<T>(
		this Task<Optional<T>> optionalTask,
		Func<T> value) where T : class
		=> (await optionalTask).WithDefault(value);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<Optional<T>> WithDefault<T>(
		this Task<Optional<T>> optionalTask,
		Func<Task<T>> value) where T : class
		=> await (await optionalTask).WithDefault(value);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<Optional<TResult>> Bind<T, TResult>(
		this Task<Optional<T>> optionalTask, Func<Optional<TResult>> map)
		where TResult : class
		where T : class
		=> (await optionalTask).Bind(map);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<Optional<TResult>> Bind<T, TResult>(
		this Task<Optional<T>> optionalTask, Func<T, Optional<TResult>> map)
		where TResult : class
		where T : class
		=> (await optionalTask).Bind(map);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<Optional<TResult>> Bind<T, TResult>(
		this Task<Optional<T>> optionalTask, Func<Task<Optional<TResult>>> map)
		where TResult : class
		where T : class
		=> await (await optionalTask).Bind(map);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<Optional<TResult>> Bind<T, TResult>(
		this Task<Optional<T>> optionalTask, Func<T, Task<Optional<TResult>>> map)
		where TResult : class
		where T : class
		=> await (await optionalTask).Bind(map);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<TResult> Match<T, TResult>(
		this Task<Optional<T>> optionalTask,
		TResult newValue,
		TResult none) where T : class
		=> (await optionalTask).Match(newValue, none);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<TResult> Match<T, TResult>(
		this Task<Optional<T>> optionalTask,
		Func<T, TResult> value,
		TResult none) where T : class
		=> (await optionalTask).Match(value, none);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<TResult> Match<T, TResult>(
		this Task<Optional<T>> optionalTask,
		Func<T, TResult> value,
		Func<TResult> none) where T : class
		=> (await optionalTask).Match(value, none);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<TResult> Match<T, TResult>(
		this Task<Optional<T>> optionalTask,
		Func<T, Task<TResult>> value,
		Func<TResult> none) where T : class
		=> await (await optionalTask).Match(value, none);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<TResult> Match<T, TResult>(
		this Task<Optional<T>> optionalTask,
		Func<T, TResult> value,
		Func<Task<TResult>> none) where T : class
		=> await (await optionalTask).Match(value, none);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<TResult> Match<T, TResult>(
		this Task<Optional<T>> optionalTask,
		Func<T, Task<TResult>> value,
		Func<Task<TResult>> none) where T : class
		=> await (await optionalTask).Match(value, none);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<Optional<T>> IfSome<T>(
		this Task<Optional<T>> optionalTask,
		Action action) where T : class
		=> (await optionalTask).IfSome(action);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<Optional<T>> IfSome<T>(
		this Task<Optional<T>> optionalTask,
		Action<T> action) where T : class
		=> (await optionalTask).IfSome(action);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<Optional<T>> IfSome<T>(
		this Task<Optional<T>> optionalTask,
		Func<Task> action) where T : class
		=> await (await optionalTask).IfSome(action);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<Optional<T>> IfSome<T>(
		this Task<Optional<T>> optionalTask,
		Func<T, Task> action) where T : class
		=> await (await optionalTask).IfSome(action);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<Optional<T>> IfNone<T>(
		this Task<Optional<T>> optionalTask,
		Action action) where T : class
		=> (await optionalTask).IfNone(action);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<Optional<T>> IfNone<T>(
		this Task<Optional<T>> optionalTask,
		Func<Task> action) where T : class
		=> await (await optionalTask).IfNone(action);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<Optional<T>> Tap<T>(
		this Task<Optional<T>> optionalTask,
		Action<Optional<T>> action) where T : class
		=> (await optionalTask).Tap(action);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task<Optional<T>> Tap<T>(
		this Task<Optional<T>> optionalTask,
		Func<Optional<T>, Task> action) where T : class
		=> await (await optionalTask).Tap(action);
}