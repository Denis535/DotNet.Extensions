#nullable enable
namespace System.Collections.Generic {
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class StatefulEnumerator<T> : IEnumerator<T> {

        private IEnumerator<T> Source { get; }
        public bool IsStarted { get; private set; }
        public bool IsCompleted { get; private set; }
        public Option<T> Current { get; private set; }

        // Constructor
        public StatefulEnumerator(IEnumerator<T> source) {
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
            if (this.Source.MoveNext()) {
                (this.IsStarted, this.IsCompleted) = (true, false);
                this.Current = Option.Create( this.Source.Current );
                return this.Current;
            }
            (this.IsStarted, this.IsCompleted) = (true, true);
            this.Current = default;
            return this.Current;
        }

        // Reset
        public void Reset() {
            this.Source.Reset();
            (this.IsStarted, this.IsCompleted) = (false, false);
            this.Current = default;
        }

    }
}
