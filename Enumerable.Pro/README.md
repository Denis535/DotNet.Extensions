# Overview
The Enumerable.Pro package provides you with a several more advanced enumerators.

# Reference
```
namespace System.Collections.Generic;
public static class EnumeratorExtensions {
    
    public static Option<T> Take<T>(this IEnumerator<T> source);

    public static StatefulEnumerator<T> AsStateful<T>(this IEnumerator<T> source);
    public static PeekableEnumerator<T> AsPeekable<T>(this IEnumerator<T> source);

}
public class StatefulEnumerator<T> : IEnumerator<T> {

    private IEnumerator<T> Source { get; }
    public bool IsStarted { get; private set; }
    public bool IsCompleted { get; private set; }
    public Option<T> Current { get; private set; }

    public StatefulEnumerator(IEnumerator<T> source);
    public void Dispose();

    object? IEnumerator.Current { get; }
    bool IEnumerator.MoveNext();
    T IEnumerator<T>.Current { get; }

    public Option<T> Take();
    public void Reset();

}
public class PeekableEnumerator<T> : IEnumerator<T> {

    private IEnumerator<T> Source { get; }
    public bool IsStarted { get; private set; }
    public bool IsCompleted { get; private set; }
    public Option<T> Current { get; private set; }
    private Option<T> Next { get; set; }

    public PeekableEnumerator(IEnumerator<T> source);
    public void Dispose();

    object? IEnumerator.Current { get; }
    bool IEnumerator.MoveNext();
    T IEnumerator<T>.Current { get; }

    public Option<T> Take();
    public Option<T> Peek();
    public void Reset();

}
public static class PeekableEnumeratorExtensions {
    
    public static Option<T> TakeIf<T>(this PeekableEnumerator<T> source, Func<T, bool> predicate);
    public static IEnumerable<T> TakeWhile<T>(this PeekableEnumerator<T> source, Func<T, bool> predicate);

}
```

# Links
- https://github.com/Denis535/DotNet.Extensions
- https://www.nuget.org/packages/Enumerable.Pro
