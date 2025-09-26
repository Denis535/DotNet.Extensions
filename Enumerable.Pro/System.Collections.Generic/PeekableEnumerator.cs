#nullable enable
namespace System.Collections.Generic {
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class PeekableEnumerator<T> : IEnumerator<T> {

        private IEnumerator<T> Source { get; }
        public bool IsStarted { get; private set; }
        public bool IsCompleted { get; private set; }
        public Option<T> Current { get; private set; }
        private Option<T> Next { get; set; }

        // Constructor
        public PeekableEnumerator(IEnumerator<T> source) {
            this.Source = source;
        }
        public void Dispose() {
            this.Source.Dispose();
        }

        // IEnumerator
        object? IEnumerator.Current => this.Current.Value;
        bool IEnumerator.MoveNext() {
            return this.Take().HasValue;
        }
        // IEnumerator<T>
        T IEnumerator<T>.Current => this.Current.Value;

        // Take
        public Option<T> Take() {
            if (this.Next.HasValue) {
                (this.IsStarted, this.IsCompleted) = (true, false);
                (this.Current, this.Next) = (this.Next, default);
                return this.Current;
            }
            if (this.Source.MoveNext()) {
                (this.IsStarted, this.IsCompleted) = (true, false);
                (this.Current, this.Next) = (Option.Create( this.Source.Current ), default);
                return this.Current;
            }
            (this.IsStarted, this.IsCompleted) = (true, true);
            (this.Current, this.Next) = (default, default);
            return this.Current;
        }

        // Peek
        public Option<T> Peek() {
            if (this.Next.HasValue) {
                return this.Next;
            }
            if (this.Source.MoveNext()) {
                this.Next = Option.Create( this.Source.Current );
                return this.Next;
            }
            this.Next = default;
            return this.Next;
        }

        // Reset
        public void Reset() {
            this.Source.Reset();
            (this.IsStarted, this.IsCompleted) = (false, false);
            (this.Current, this.Next) = (default, default);
        }

    }
    public static class PeekableEnumeratorExtensions {

        // Take/If
        public static Option<T> TakeIf<T>(this PeekableEnumerator<T> source, Func<T, bool> predicate) {
            if (source.Peek().TryGetValue( out var next ) && predicate( next )) {
                return source.Take();
            }
            return default;
        }

        // Take/While
        public static IEnumerable<T> TakeWhile<T>(this PeekableEnumerator<T> source, Func<T, bool> predicate) {
            // [true, true], false
            while (source.Peek().TryGetValue( out var next ) && predicate( next )) {
                yield return source.Take().Value;
            }
        }

    }
}
