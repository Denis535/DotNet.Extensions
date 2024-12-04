namespace System {
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Tests {

        [Test]
        public void Test_00() {
            {
                var value = (Option<int>) default;
                Assert.That( value.HasValue, Is.False );
                Assert.Throws<InvalidOperationException>( () => _ = value.Value );
                Assert.That( value.ValueOrDefault, Is.Zero );

                Assert.That( value.ToString(), Is.EqualTo( "Nothing" ) );
                Assert.That( value.Equals( (Option<int>) default ), Is.True );
                Assert.That( value.Equals( 0 ), Is.False );
                Assert.That( value.GetHashCode(), Is.EqualTo( 0 ) );
            }
            {
                var value = Option.Create( 1 );
                Assert.That( value.HasValue, Is.True );
                Assert.That( value.Value, Is.EqualTo( 1 ) );
                Assert.That( value.ValueOrDefault, Is.EqualTo( 1 ) );

                Assert.That( value.ToString(), Is.EqualTo( "1" ) );
                Assert.That( value.Equals( Option.Create( 1 ) ), Is.True );
                Assert.That( value.Equals( 1 ), Is.True );
                Assert.That( value.GetHashCode(), Is.EqualTo( 1.GetHashCode() ) );
            }
            {
                var value = Option.Create<int>( null );
                Assert.That( value.HasValue, Is.False );
                Assert.Throws<InvalidOperationException>( () => _ = value.Value );
                Assert.That( value.ValueOrDefault, Is.Zero );

                Assert.That( value.ToString(), Is.EqualTo( "Nothing" ) );
                Assert.That( value.Equals( (Option<int>) default ), Is.True );
                Assert.That( value.Equals( 0 ), Is.False );
                Assert.That( value.GetHashCode(), Is.EqualTo( 0 ) );
            }
        }

        [Test]
        public void Test_10() {
            var value = Option.Create( 1 );
            var other = Option.Create( 2 );

            Assert.That( value.Equals( other ), Is.EqualTo( EqualityComparer<int>.Default.Equals( value.Value, other.Value ) ) );
            Assert.That( value.CompareTo( other ), Is.EqualTo( Comparer<int>.Default.Compare( value.Value, other.Value ) ) );

            Assert.That( Option.Equals( value, other ), Is.EqualTo( EqualityComparer<int>.Default.Equals( value.Value, other.Value ) ) );
            Assert.That( Option.Compare( value, other ), Is.EqualTo( Comparer<int>.Default.Compare( value.Value, other.Value ) ) );
        }
        [Test]
        public void Test_11() {
            var value = Option.Create( 1 );
            var other = Option.Create<int>( null );

            Assert.That( value.Equals( other ), Is.EqualTo( EqualityComparer<bool>.Default.Equals( value.HasValue, other.HasValue ) ) );
            Assert.That( value.CompareTo( other ), Is.EqualTo( Comparer<bool>.Default.Compare( value.HasValue, other.HasValue ) ) );

            Assert.That( Option.Equals( value, other ), Is.EqualTo( EqualityComparer<bool>.Default.Equals( value.HasValue, other.HasValue ) ) );
            Assert.That( Option.Compare( value, other ), Is.EqualTo( Comparer<bool>.Default.Compare( value.HasValue, other.HasValue ) ) );
        }
        [Test]
        public void Test_12() {
            var value = Option.Create<int>( null );
            var other = Option.Create( 2 );

            Assert.That( value.Equals( other ), Is.EqualTo( EqualityComparer<bool>.Default.Equals( value.HasValue, other.HasValue ) ) );
            Assert.That( value.CompareTo( other ), Is.EqualTo( Comparer<bool>.Default.Compare( value.HasValue, other.HasValue ) ) );

            Assert.That( Option.Equals( value, other ), Is.EqualTo( EqualityComparer<bool>.Default.Equals( value.HasValue, other.HasValue ) ) );
            Assert.That( Option.Compare( value, other ), Is.EqualTo( Comparer<bool>.Default.Compare( value.HasValue, other.HasValue ) ) );
        }

        [Test]
        public void Test_20() {
            var value = Option.Create( 1 );
            var other = 2;

            Assert.That( value.Equals( other ), Is.EqualTo( EqualityComparer<int>.Default.Equals( value.Value, other ) ) );
            Assert.That( value.CompareTo( other ), Is.EqualTo( Comparer<int>.Default.Compare( value.Value, other ) ) );

            Assert.That( Option.Equals( value, other ), Is.EqualTo( EqualityComparer<int>.Default.Equals( value.Value, other ) ) );
            Assert.That( Option.Compare( value, other ), Is.EqualTo( Comparer<int>.Default.Compare( value.Value, other ) ) );
        }
        [Test]
        public void Test_21() {
            var value = Option.Create<int>( null );
            var other = 2;

            Assert.That( value.Equals( other ), Is.EqualTo( EqualityComparer<bool>.Default.Equals( value.HasValue, true ) ) );
            Assert.That( value.CompareTo( other ), Is.EqualTo( Comparer<bool>.Default.Compare( value.HasValue, true ) ) );

            Assert.That( Option.Equals( value, other ), Is.EqualTo( EqualityComparer<bool>.Default.Equals( value.HasValue, true ) ) );
            Assert.That( Option.Compare( value, other ), Is.EqualTo( Comparer<bool>.Default.Compare( value.HasValue, true ) ) );
        }

        [Test]
        public void Test_30() {
            var value = 1;
            var other = Option.Create( 2 );

            Assert.That( Option.Equals( value, other ), Is.EqualTo( EqualityComparer<int>.Default.Equals( value, other.Value ) ) );
            Assert.That( Option.Compare( value, other ), Is.EqualTo( Comparer<int>.Default.Compare( value, other.Value ) ) );
        }
        [Test]
        public void Test_31() {
            var value = 1;
            var other = Option.Create<int>( null );

            Assert.That( Option.Equals( value, other ), Is.EqualTo( EqualityComparer<bool>.Default.Equals( true, other.HasValue ) ) );
            Assert.That( Option.Compare( value, other ), Is.EqualTo( Comparer<bool>.Default.Compare( true, other.HasValue ) ) );
        }

    }
}
