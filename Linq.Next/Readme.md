# Overview
The Linq.Next package provides you with a useful additions to the Linq.

# Reference
```
namespace System.Linq;
public static class LinqNext {

    // Split
    // Split the items into segments (the separator is excluded)
    // Example: [false, false, false], true, [false, false, false]
    public static IEnumerable<T[]> Split<T>(this IEnumerable<T> source, Func<T, bool> separatorPredicate);
    public static IEnumerable<TResult[]> Split<T, TResult>(this IEnumerable<T> source, Func<T, bool> separatorPredicate, Func<T, TResult> resultSelector);
    public static IEnumerable<IList<TResult>> FastSplit<T, TResult>(this IEnumerable<T> source, Func<T, bool> separatorPredicate, Func<T, TResult> resultSelector);

    // Split/Before
    // Split the items into segments (the separator is included at the beginning of segment)
    // Example: [false, false, false], [true, false, false]
    public static IEnumerable<T[]> SplitBefore<T>(this IEnumerable<T> source, Func<T, bool> separatorPredicate);
    public static IEnumerable<TResult[]> SplitBefore<T, TResult>(this IEnumerable<T> source, Func<T, bool> separatorPredicate, Func<T, TResult> resultSelector);
    public static IEnumerable<IList<TResult>> FastSplitBefore<T, TResult>(this IEnumerable<T> source, Func<T, bool> separatorPredicate, Func<T, TResult> resultSelector);

    // Split/After
    // Split the items into segments (the separator is included at the end of segment)
    // Example: [false, false, true], [false, false, false]
    public static IEnumerable<T[]> SplitAfter<T>(this IEnumerable<T> source, Func<T, bool> separatorPredicate);
    public static IEnumerable<TResult[]> SplitAfter<T, TResult>(this IEnumerable<T> source, Func<T, bool> separatorPredicate, Func<T, TResult> resultSelector);
    public static IEnumerable<IList<TResult>> FastSplitAfter<T, TResult>(this IEnumerable<T> source, Func<T, bool> separatorPredicate, Func<T, TResult> resultSelector);

    // Slice
    // Slice the items into slices
    // Example: [true, true, true], [false, true, true]
    public static IEnumerable<T[]> Slice<T>(this IEnumerable<T> source, Func<T, IList<T>, bool> belongsToSlicePredicate);
    public static IEnumerable<TResult[]> Slice<T, TResult>(this IEnumerable<T> source, Func<T, IList<TResult>, bool> belongsToSlicePredicate, Func<T, TResult> resultSelector);
    public static IEnumerable<IList<TResult>> FastSlice<T, TResult>(this IEnumerable<T> source, Func<T, IList<TResult>, bool> belongsToSlicePredicate, Func<T, TResult> resultSelector);

    // Unflatten
    // Unflatten the items into key-values pairs
    // Example: true: [false, false, false], true: [false, false, false]
    // Example: key: [value, value, value], key: [value, value, value]
    public static IEnumerable<(Option<T> Key, T[] Values)> Unflatten<T>(this IEnumerable<T> source, Func<T, bool> keyPredicate);
    public static IEnumerable<(Option<TKey> Key, TValue[] Values)> Unflatten<T, TKey, TValue>(this IEnumerable<T> source, Func<T, bool> keyPredicate, Func<T, TKey> keySelector, Func<T, TValue> valueSelector);
    public static IEnumerable<(Option<TKey> Key, IList<TValue> Values)> FastUnflatten<T, TKey, TValue>(this IEnumerable<T> source, Func<T, bool> keyPredicate, Func<T, TKey> keySelector, Func<T, TValue> valueSelector);

    // With/Prev
    public static IEnumerable<(T Value, Option<T> Prev)> WithPrev<T>(this IEnumerable<T> source);
    // With/Next
    public static IEnumerable<(T Value, Option<T> Next)> WithNext<T>(this IEnumerable<T> source);
    // With/Prev-Next
    public static IEnumerable<(T Value, Option<T> Prev, Option<T> Next)> WithPrevNext<T>(this IEnumerable<T> source);

    // Tag/First
    public static IEnumerable<(T Value, bool IsFirst)> TagFirst<T>(this IEnumerable<T> source);
    // Tag/Last
    public static IEnumerable<(T Value, bool IsLast)> TagLast<T>(this IEnumerable<T> source);
    // Tag/First-Last
    public static IEnumerable<(T Value, bool IsFirst, bool IsLast)> TagFirstLast<T>(this IEnumerable<T> source);

    // CompareTo
    public static void CompareTo<T>(this IEnumerable<T> actual, IEnumerable<T> expected, out T[] missing, out T[] extra);

}
```

# Links
- https://github.com/Denis535/Net.Extensions
- https://www.nuget.org/packages/Linq.Next
