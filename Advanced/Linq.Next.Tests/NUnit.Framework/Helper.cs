namespace NUnit.Framework {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal static class Helper {

        public static T Value<T>(T value) {
            return value;
        }
        public static Option<T> Option<T>(T value) {
            return value != null ? System.Option.Create( value ) : default;
        }
        public static Option<T> Option<T>(T? value) where T : struct {
            return value != null ? System.Option.Create( value.Value ) : default;
        }

        public static T[] Values<T>(params T[] values) {
            return values;
        }
        public static Option<T>[] Options<T>(params T[] values) {
            return values.Select( i => i != null ? System.Option.Create( i ) : default ).ToArray();
        }
        public static Option<T>[] Options<T>(params T?[] values) where T : struct {
            return values.Select( i => i != null ? System.Option.Create( i.Value ) : default ).ToArray();
        }

        public static IEnumerator<T> Enumerator<T>(params T[] values) {
            return values.AsEnumerable().GetEnumerator();
        }
        public static StatefulEnumerator<T> Stateful<T>(params T[] values) {
            return values.AsEnumerable().GetEnumerator().AsStateful();
        }
        public static PeekableEnumerator<T> Peekable<T>(params T[] values) {
            return values.AsEnumerable().GetEnumerator().AsPeekable();
        }

        public static Func<bool> Predicate(Func<bool> predicate) {
            return predicate;
        }
        public static Func<T1, bool> Predicate<T1>(Func<T1, bool> predicate) {
            return predicate;
        }
        public static Func<T1, T2, bool> Predicate<T1, T2>(Func<T1, T2, bool> predicate) {
            return predicate;
        }
        public static Func<T1, T2, T3, bool> Predicate<T1, T2, T3>(Func<T1, T2, T3, bool> predicate) {
            return predicate;
        }
        public static Func<T1, T2, T3, T4, bool> Predicate<T1, T2, T3, T4>(Func<T1, T2, T3, T4, bool> predicate) {
            return predicate;
        }
        public static Func<T1, T2, T3, T4, T5, bool> Predicate<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5, bool> predicate) {
            return predicate;
        }
        public static Func<T1, T2, T3, T4, T5, T6, bool> Predicate<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, T6, bool> predicate) {
            return predicate;
        }

    }
}
