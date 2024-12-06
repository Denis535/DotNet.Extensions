namespace System {
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Tests_01 {

        [Test]
        public void Test_00_EqualTo() {
            {
                // Option IsEqualTo Option
                var value = Option.Create( 1 );
                var other = Option.Create( 2 );
                Assert.That( value.IsEqualTo( other ), Is.EqualTo( EqualityComparer<int>.Default.Equals( value.Value, other.Value ) ) );

                value = Option.Create( 1 );
                other = Option.Create<int>( null );
                Assert.That( value.IsEqualTo( other ), Is.EqualTo( EqualityComparer<bool>.Default.Equals( value.HasValue, other.HasValue ) ) );

                value = Option.Create<int>( null );
                other = Option.Create( 2 );
                Assert.That( value.IsEqualTo( other ), Is.EqualTo( EqualityComparer<bool>.Default.Equals( value.HasValue, other.HasValue ) ) );
            }
            {
                // Option IsEqualTo Value
                var value = Option.Create( 1 );
                var other = 2;
                Assert.That( value.IsEqualTo( other ), Is.EqualTo( EqualityComparer<int>.Default.Equals( value.Value, other ) ) );

                value = Option.Create<int>( null );
                other = 2;
                Assert.That( value.IsEqualTo( other ), Is.EqualTo( EqualityComparer<bool>.Default.Equals( value.HasValue, true ) ) );
            }
        }

        [Test]
        public void Test_01_CompareTo() {
            {
                // Option CompareTo Option
                var value = Option.Create( 1 );
                var other = Option.Create( 2 );
                Assert.That( value.CompareTo( other ), Is.EqualTo( Comparer<int>.Default.Compare( value.Value, other.Value ) ) );

                value = Option.Create( 1 );
                other = Option.Create<int>( null );
                Assert.That( value.CompareTo( other ), Is.EqualTo( Comparer<bool>.Default.Compare( value.HasValue, other.HasValue ) ) );

                value = Option.Create<int>( null );
                other = Option.Create( 2 );
                Assert.That( value.CompareTo( other ), Is.EqualTo( Comparer<bool>.Default.Compare( value.HasValue, other.HasValue ) ) );
            }
            {
                // Option CompareTo Value
                var value = Option.Create( 1 );
                var other = 2;
                Assert.That( value.CompareTo( other ), Is.EqualTo( Comparer<int>.Default.Compare( value.Value, other ) ) );

                value = Option.Create<int>( null );
                other = 2;
                Assert.That( value.CompareTo( other ), Is.EqualTo( Comparer<bool>.Default.Compare( value.HasValue, true ) ) );
            }
        }

    }
}
