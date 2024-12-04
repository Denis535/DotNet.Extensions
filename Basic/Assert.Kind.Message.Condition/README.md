# Overview
The assertion library with a very convenient method chaining api (aka fluent interface).

# Reference
```
public static class Assert {
    public static class Argument {
        public static Assertions.Argument Message(FormattableString? value);
    }
    public static class Operation {
        public static Assertions.Operation Message(FormattableString? value);
    }
}
public static class Assertions {
    public readonly struct Argument {
        public void Valid(bool isValid);
        public void NotNull(bool isValid);
        public void InRange(bool isValid);
    }
    public readonly struct Operation {
        public void Valid(bool isValid);
        public void Ready(bool isValid);
        public void NotDisposed(bool isValid);
    }
}
public static class Exceptions {
    public static class Argument {
        public static ArgumentException ArgumentException(FormattableString? message);
        public static ArgumentNullException ArgumentNullException(FormattableString? message);
        public static ArgumentOutOfRangeException ArgumentOutOfRangeException(FormattableString? message);
    }
    public static class Operation {
        public static InvalidOperationException InvalidOperationException(FormattableString? message);
        public static ObjectNotReadyException ObjectNotReadyException(FormattableString? message);
        public static ObjectDisposedException ObjectDisposedException(FormattableString? message);
    }
    public static class Internal {
        public static Exception Exception(FormattableString? message);
        public static NullReferenceException NullReference(FormattableString? message);
        public static NotSupportedException NotSupported(FormattableString? message);
        public static NotImplementedException NotImplemented(FormattableString? message);
    }
}
```

# Example
```
// Assert.Argument
Assert.Argument.Message( $"ArgumentException" ).Valid( ... )
Assert.Argument.Message( $"ArgumentNullException" ).NotNull( ... )
Assert.Argument.Message( $"ArgumentOutOfRangeException" ).InRange( ... )
// Assert.Operation
Assert.Operation.Message( $"InvalidOperationException" ).Valid( ... )
Assert.Operation.Message( $"ObjectNotReadyException" ).Ready( ... )
Assert.Operation.Message( $"ObjectDisposedException" ).NotDisposed( ... )

// Exceptions.Argument
throw Exceptions.Argument.ArgumentException( $"ArgumentException" )
throw Exceptions.Argument.ArgumentNullException( $"ArgumentNullException" )
throw Exceptions.Argument.ArgumentOutOfRangeException( $"ArgumentOutOfRangeException" )
// Exceptions.Operation
throw Exceptions.Operation.InvalidOperationException( $"InvalidOperationException" )
throw Exceptions.Operation.ObjectNotReadyException( $"ObjectNotReadyException" )
throw Exceptions.Operation.ObjectDisposedException( $"ObjectDisposedException" )
// Exceptions.Internal
throw Exceptions.Internal.Exception( $"Exception" )
throw Exceptions.Internal.NullReference( $"NullReferenceException" )
throw Exceptions.Internal.NotSupported( $"NotSupportedException" )
throw Exceptions.Internal.NotImplemented( $"NotImplementedException" )
```

# Link
- https://github.com/denis535/Net.Extensions
- https://www.nuget.org/packages/Assert.Kind.Message.Condition

# P.S.
Note that it is preferable to check the arguments first, and then everything else.
This is because other checks may depend on the validity of the your arguments.
