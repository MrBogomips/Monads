// ReSharper disable MemberCanBeProtected.Global
namespace Bogoware.Monads;

/// <summary>
/// This class can be further inherited to model specific domain error needs.
/// </summary>
/// <example>
/// public class DomainError: LogicError
/// {
/// 	public enum ErrorSeverity
/// 	{
/// 		Low,
/// 		Medium,
/// 		High
/// 	}
/// 	
/// 	public int Code { get; }
/// 	public ErrorSeverity Severity { get; }
/// 	public DomainError(string message, int code, ErrorSeverity severity = ErrorSeverity.Low)
/// 		: base(message)
/// 	{
/// 		Code = code;
/// 		Severity = severity;
/// 	}
/// }
/// </example>
public class LogicError: Error, IEquatable<LogicError>
{
	public override string Message { get; }
	public LogicError(string message)
	{
		ArgumentNullException.ThrowIfNull(message);
		Message = message;
	}

	public bool Equals(LogicError? other)
	{
		if (ReferenceEquals(null, other)) return false;
		if (ReferenceEquals(this, other)) return true;
		return Message == other.Message;
	}

	public override bool Equals(object? obj) => Equals(obj as LogicError);

	public override int GetHashCode() => Message.GetHashCode();

	public static bool operator ==(LogicError? left, LogicError? right) => Equals(left, right);

	public static bool operator !=(LogicError? left, LogicError? right) => !Equals(left, right);
	public void Deconstruct(out string message)
	{
		message = Message;
	}

	public override string ToString() => $"""LogicError: "{Message}".""";
}