namespace Bogoware.Monads;

public interface IResult
{
	bool IsSuccess { get; }
	bool IsFailure { get; }
}