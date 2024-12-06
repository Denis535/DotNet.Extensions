# Overview
The Valuable.Pro package provides you with a lazily evaluated value and several useful chaining methods like Linq.

# Reference
```
namespace System;
public interface IValuable<T> {

    bool TryGetValue([MaybeNullWhen( false )] out T value);

}
public static class Valuable {

    public static IValuable<T> Create<T>();
    public static IValuable<T> Create<T>(this T value);

    public static IValuable<TResult> Select<T, TResult>(this IValuable<T> valuable, Func<T, TResult> selector);
    public static IValuable<T> Where<T>(this IValuable<T> valuable, Func<T, bool> predicate);
    
    public static T Value<T>(this IValuable<T> valuable);
    public static T? ValueOrDefault<T>(this IValuable<T> valuable);

}
```

# Links
- https://github.com/Denis535/DotNet.Extensions
- https://www.nuget.org/packages/Valuable.Pro
