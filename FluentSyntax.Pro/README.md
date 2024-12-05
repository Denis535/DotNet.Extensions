# Overview
The FluentSyntax.Pro package provides you with a several useful chaining methods for convenient value processing.

# Reference
```
namespace System;
public static class LangExtensions {

    public static T Chain<T>(this T value, Action<T> callback);
    public static TResult Pipe<T, TResult>(this T value, Func<T, TResult> converter);
    public static Option<T> If<T>(this T value, Func<T, bool> predicate);

    public static Option<T> Chain2<T>(this Option<T> value, Action<T> callback);
    public static Option<TResult> Pipe2<T, TResult>(this Option<T> value, Func<T, TResult> converter);
    public static Option<T> If2<T>(this Option<T> value, Func<T, bool> predicate);

}
```

# Links
- https://github.com/Denis535/DotNet.Extensions
- https://www.nuget.org/packages/FluentSyntax.Pro
