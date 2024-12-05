namespace System.Collections.Generic {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;

    public class Tests_PeekableEnumerator {

        // Constructor
        [Test]
        public void Constructor() {
            using var source = new int[] { 0, 1, 2 }.AsEnumerable().GetEnumerator().AsPeekable();
            Assert.That( source.IsStarted, Is.False );
            Assert.That( source.IsCompleted, Is.False );
            Assert.That( source.Current, Is.EqualTo( Option.Create<int>( null ) ) );
        }

        // Take
        [Test]
        public void Take() {
            {
                using var source = new int[] { }.AsEnumerable().GetEnumerator().AsPeekable();
                {
                    var next = source.Peek();
                    Assert.That( next, Is.EqualTo( source.Peek() ) );
                    AssertThatEqualTo( source, false, false, null, null );
                }
                {
                    var current = source.Take();
                    Assert.That( current, Is.EqualTo( source.Current ) );
                    AssertThatEqualTo( source, true, true, null, null );
                }
                {
                    var next = source.Peek();
                    Assert.That( next, Is.EqualTo( source.Peek() ) );
                    AssertThatEqualTo( source, true, true, null, null );
                }
            }
            {
                using var source = new int[] { 0, 1, 2 }.AsEnumerable().GetEnumerator().AsPeekable();
                {
                    var next = source.Peek();
                    Assert.That( next, Is.EqualTo( source.Peek() ) );
                    AssertThatEqualTo( source, false, false, null, 0 );
                }
                {
                    var current = source.Take();
                    Assert.That( current, Is.EqualTo( source.Current ) );
                    AssertThatEqualTo( source, true, false, 0, 1 );
                }
                {
                    var next = source.Peek();
                    Assert.That( next, Is.EqualTo( source.Peek() ) );
                    AssertThatEqualTo( source, true, false, 0, 1 );
                }
                {
                    var current = source.Take();
                    Assert.That( current, Is.EqualTo( source.Current ) );
                    AssertThatEqualTo( source, true, false, 1, 2 );
                }
                {
                    var next = source.Peek();
                    Assert.That( next, Is.EqualTo( source.Peek() ) );
                    AssertThatEqualTo( source, true, false, 1, 2 );
                }
                {
                    var current = source.Take();
                    Assert.That( current, Is.EqualTo( source.Current ) );
                    AssertThatEqualTo( source, true, false, 2, null );
                }
                {
                    var next = source.Peek();
                    Assert.That( next, Is.EqualTo( source.Peek() ) );
                    AssertThatEqualTo( source, true, false, 2, null );
                }
                {
                    var current = source.Take();
                    Assert.That( current, Is.EqualTo( source.Current ) );
                    AssertThatEqualTo( source, true, true, null, null );
                }
                {
                    var next = source.Peek();
                    Assert.That( next, Is.EqualTo( source.Peek() ) );
                    AssertThatEqualTo( source, true, true, null, null );
                }
            }
            static void AssertThatEqualTo(PeekableEnumerator<int> source, bool expected_isStarted, bool expected_isFinished, int? expected_current, int? expected_next) {
                Assert.That( source.IsStarted, Is.EqualTo( expected_isStarted ) );
                Assert.That( source.IsCompleted, Is.EqualTo( expected_isFinished ) );
                Assert.That( source.Current, Is.EqualTo( Option.Create<int>( expected_current ) ) );
                Assert.That( source.Peek(), Is.EqualTo( Option.Create<int>( expected_next ) ) );
            }
        }

        // Take/If
        [Test]
        public void TakeIf() {
            using var source = new int[] { 0, 1, 2 }.AsEnumerable().GetEnumerator().AsPeekable();
            Assert.That( source.TakeIf( i => false ), Is.EqualTo( Option.Create<int>( null ) ) );
            Assert.That( source.TakeIf( i => true ), Is.EqualTo( Option.Create( 0 ) ) );
            Assert.That( source.TakeIf( i => false ), Is.EqualTo( Option.Create<int>( null ) ) );
            Assert.That( source.TakeIf( i => true ), Is.EqualTo( Option.Create( 1 ) ) );
            Assert.That( source.TakeIf( i => false ), Is.EqualTo( Option.Create<int>( null ) ) );
            Assert.That( source.TakeIf( i => true ), Is.EqualTo( Option.Create( 2 ) ) );
            Assert.That( source.TakeIf( i => true ), Is.EqualTo( Option.Create<int>( null ) ) );
        }

        // Take/While
        [Test]
        public void TakeWhile() {
            using var source = new int[] { 0, 1, 2 }.AsEnumerable().GetEnumerator().AsPeekable();
            Assert.That( source.TakeWhile( i => false ), Is.EqualTo( new int[] { } ) );
            Assert.That( source.TakeWhile( i => i == 0 ), Is.EqualTo( new int[] { 0 } ) );
            Assert.That( source.TakeWhile( i => false ), Is.EqualTo( new int[] { } ) );
            Assert.That( source.TakeWhile( i => true ), Is.EqualTo( new int[] { 1, 2 } ) );
            Assert.That( source.TakeWhile( i => false ), Is.EqualTo( new int[] { } ) );
        }

        // Reset
        [Test]
        public void Reset() {
            using var source = new int[] { 0, 1, 2 }.AsEnumerable().GetEnumerator().AsPeekable();
            ((IEnumerator<int>) source).MoveNext();

            source.Reset();
            Assert.That( source.IsStarted, Is.False );
            Assert.That( source.IsCompleted, Is.False );
            Assert.That( source.Current, Is.EqualTo( Option.Create<int>( null ) ) );
        }

    }
}
