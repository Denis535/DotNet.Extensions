namespace System {
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Tests_02 {

        [Test]
        public void Test_00_AreEqual() {
            {
                // AreEqual Option Option
                var value = Option.Some( 1 );
                var other = Option.Some( 2 );
                Assert.That( Option.AreEqual( value, other ), Is.EqualTo( EqualityComparer<int>.Default.Equals( value.Value, other.Value ) ) );

                value = Option.Some( 1 );
                other = Option.From<int>( null );
                Assert.That( Option.AreEqual( value, other ), Is.EqualTo( EqualityComparer<bool>.Default.Equals( value.HasValue, other.HasValue ) ) );

                value = Option.From<int>( null );
                other = Option.Some( 2 );
                Assert.That( Option.AreEqual( value, other ), Is.EqualTo( EqualityComparer<bool>.Default.Equals( value.HasValue, other.HasValue ) ) );
            }
            {
                // AreEqual Option Value
                var value = Option.Some( 1 );
                var other = 2;
                Assert.That( Option.AreEqual( value, other ), Is.EqualTo( EqualityComparer<int>.Default.Equals( value.Value, other ) ) );

                value = Option.From<int>( null );
                other = 2;
                Assert.That( Option.AreEqual( value, other ), Is.EqualTo( EqualityComparer<bool>.Default.Equals( value.HasValue, true ) ) );
            }
            {
                // AreEqual Value Option
                var value = 1;
                var other = Option.Some( 2 );
                Assert.That( Option.AreEqual( value, other ), Is.EqualTo( EqualityComparer<int>.Default.Equals( value, other.Value ) ) );

                value = 1;
                other = Option.From<int>( null );
                Assert.That( Option.AreEqual( value, other ), Is.EqualTo( EqualityComparer<bool>.Default.Equals( true, other.HasValue ) ) );
            }
        }

        [Test]
        public void Test_01_Compare() {
            {
                // Compare Option Option
                var value = Option.Some( 1 );
                var other = Option.Some( 2 );
                Assert.That( Option.Compare( value, other ), Is.EqualTo( Comparer<int>.Default.Compare( value.Value, other.Value ) ) );

                value = Option.Some( 1 );
                other = Option.From<int>( null );
                Assert.That( Option.Compare( value, other ), Is.EqualTo( Comparer<bool>.Default.Compare( value.HasValue, other.HasValue ) ) );

                value = Option.From<int>( null );
                other = Option.Some( 2 );
                Assert.That( Option.Compare( value, other ), Is.EqualTo( Comparer<bool>.Default.Compare( value.HasValue, other.HasValue ) ) );
            }
            {
                // Compare Option Value
                var value = Option.Some( 1 );
                var other = 2;
                Assert.That( Option.Compare( value, other ), Is.EqualTo( Comparer<int>.Default.Compare( value.Value, other ) ) );

                value = Option.From<int>( null );
                other = 2;
                Assert.That( Option.Compare( value, other ), Is.EqualTo( Comparer<bool>.Default.Compare( value.HasValue, true ) ) );
            }
            {
                // Compare Value Option
                var value = 1;
                var other = Option.Some( 2 );
                Assert.That( Option.Compare( value, other ), Is.EqualTo( Comparer<int>.Default.Compare( value, other.Value ) ) );

                value = 1;
                other = Option.From<int>( null );
                Assert.That( Option.Compare( value, other ), Is.EqualTo( Comparer<bool>.Default.Compare( true, other.HasValue ) ) );
            }
        }

        [Test]
        public void Test_02_GetUnderlyingType() {
            Assert.That( Option.GetUnderlyingType( typeof( Option<int> ) ), Is.EqualTo( typeof( int ) ) );
        }

    }
}
