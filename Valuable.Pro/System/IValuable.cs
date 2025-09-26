#nullable enable
namespace System {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public interface IValuable<T> {

        bool TryGetValue([MaybeNullWhen( false )] out T value);

    }
    internal readonly struct Valuable_Empty<T> : IValuable<T> {

        //public Valuable_Empty() {
        //}

        public bool TryGetValue([MaybeNullWhen( false )] out T value) {
            value = default;
            return false;
        }

    }
    internal readonly struct Valuable_Value<T> : IValuable<T> {

        private readonly T m_Value;

        public Valuable_Value(T value) {
            this.m_Value = value;
        }

        public bool TryGetValue([MaybeNullWhen( false )] out T value) {
            value = this.m_Value;
            return true;
        }

    }
    internal readonly struct Valuable_ValueSelector<T, TResult> : IValuable<TResult> {

        private readonly IValuable<T> m_Source;
        private readonly Func<T, TResult> m_Selector;

        public Valuable_ValueSelector(IValuable<T> source, Func<T, TResult> selector) {
            this.m_Source = source;
            this.m_Selector = selector;
        }

        public bool TryGetValue([MaybeNullWhen( false )] out TResult value) {
            if (this.m_Source.TryGetValue( out var tmp )) {
                value = this.m_Selector( tmp );
                return true;
            }
            value = default;
            return false;
        }

    }
    internal readonly struct Valuable_ValueFilter<T> : IValuable<T> {

        private readonly IValuable<T> m_Source;
        private readonly Func<T, bool> m_Predicate;

        public Valuable_ValueFilter(IValuable<T> source, Func<T, bool> predicate) {
            this.m_Source = source;
            this.m_Predicate = predicate;
        }

        public bool TryGetValue([MaybeNullWhen( false )] out T value) {
            if (this.m_Source.TryGetValue( out var tmp )) {
                if (this.m_Predicate( tmp )) {
                    value = tmp;
                    return true;
                }
            }
            value = default;
            return false;
        }

    }
}
