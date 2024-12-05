# Overview
The Option.Pro package provides you with a container that may have some value (null is also valid value) or may have nothing.

# Reference
```
public static class Option {

    public static Option<T> Create<T>();
    public static Option<T> Create<T>(T value);
    public static Option<T> Create<T>(T? value);

    public static bool Equals<T>(Option<T> value, Option<T> other);
    public static bool Equals<T>(Option<T> value, T other);
    public static bool Equals<T>(T value, Option<T> other);

    public static int Compare<T>(Option<T> value, Option<T> other);
    public static int Compare<T>(Option<T> value, T other);
    public static int Compare<T>(T value, Option<T> other);

    public static Type GetUnderlyingType(Type type);

}
[Serializable]
public readonly struct Option<T> : IEquatable<Option<T>>, IEquatable<T>, IComparable<Option<T>>, IComparable<T> {

    public bool HasValue { get; }
    public T Value { get; }
    public T? ValueOrDefault { get; }

    public Option();

    public bool TryGetValue(out T? value);

    public bool Equals(Option<T> other);
    public bool Equals(T other);

    public int CompareTo(Option<T> other);
    public int CompareTo(T other);

    public override string ToString();
    public override bool Equals(object? other);
    public override int GetHashCode();

    public static bool operator ==(Option<T> left, Option<T> right);
    public static bool operator ==(Option<T> left, T right);
    public static bool operator ==(T left, Option<T> right);

    public static bool operator !=(Option<T> left, Option<T> right);
    public static bool operator !=(Option<T> left, T right);
    public static bool operator !=(T left, Option<T> right);

}
```

# Links
- https://github.com/denis535/Net.Extensions
- https://www.nuget.org/packages/Option.Pro
