namespace System.Collections.Generic {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;

    public class Tests_StatefulEnumerator {

        // Constructor
        [Test]
        public void Constructor() {
            using var source = new int[] { 0, 1, 2 }.AsEnumerable().GetEnumerator().AsStateful();
            Assert.That( source.IsStarted, Is.False );
            Assert.That( source.IsCompleted, Is.False );
            Assert.That( source.Current, Is.EqualTo( Option.Create<int>( null ) ) );
        }

        // Take
        [Test]
        public void Take() {
            {
                using var source = new int[] { }.AsEnumerable().GetEnumerator().AsStateful();
                {
                    var current = source.Take();
                    Assert.That( current, Is.EqualTo( source.Current ) );
                    AssertThatEqualTo( source, true, true, null );
                }
            }
            {
                using var source = new int[] { 0, 1, 2 }.AsEnumerable().GetEnumerator().AsStateful();
                {
                    var current = source.Take();
                    Assert.That( current, Is.EqualTo( source.Current ) );
                    AssertThatEqualTo( source, true, false, 0 );
                }
                {
                    var current = source.Take();
                    Assert.That( current, Is.EqualTo( source.Current ) );
                    AssertThatEqualTo( source, true, false, 1 );
                }
                {
                    var current = source.Take();
                    Assert.That( current, Is.EqualTo( source.Current ) );
                    AssertThatEqualTo( source, true, false, 2 );
                }
                {
                    var current = source.Take();
                    Assert.That( current, Is.EqualTo( source.Current ) );
                    AssertThatEqualTo( source, true, true, null );
                }
            }
            static void AssertThatEqualTo(StatefulEnumerator<int> source, bool expected_isStarted, bool expected_isFinished, int? expected_current) {
                Assert.That( source.IsStarted, Is.EqualTo( expected_isStarted ) );
                Assert.That( source.IsCompleted, Is.EqualTo( expected_isFinished ) );
                Assert.That( source.Current, Is.EqualTo( Option.Create( expected_current ) ) );
            }
        }

        // Reset
        [Test]
        public void Reset() {
            using var source = new int[] { 0, 1, 2 }.AsEnumerable().GetEnumerator().AsStateful();
            _ = ((IEnumerator<int>) source).MoveNext();

            source.Reset();
            Assert.That( source.IsStarted, Is.False );
            Assert.That( source.IsCompleted, Is.False );
            Assert.That( source.Current, Is.EqualTo( Option.Create<int>( null ) ) );
        }

    }
}
