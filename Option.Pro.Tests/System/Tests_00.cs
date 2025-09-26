namespace System {
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Tests_00 {

        [Test]
        public void Test_00_Some() {
            {
                var value = Option.Some( 777 );
                Assert.That( value.HasValue, Is.True );
                Assert.That( value.Value, Is.EqualTo( 777 ) );
                Assert.That( value.ValueOrDefault, Is.EqualTo( 777 ) );
                Assert.That( value.ToString(), Is.EqualTo( "777" ) );
            }
        }

        [Test]
        public void Test_01_None() {
            {
                var value = Option.None<int>();
                Assert.That( value.HasValue, Is.False );
                _ = Assert.Throws<InvalidOperationException>( () => _ = value.Value );
                Assert.That( value.ValueOrDefault, Is.Zero );
                Assert.That( value.ToString(), Is.EqualTo( "None" ) );
            }
        }

        [Test]
        public void Test_03_From() {
            {
                var value = Option.From<int>( 777 );
                Assert.That( value.HasValue, Is.True );
                Assert.That( value.Value, Is.EqualTo( 777 ) );
                Assert.That( value.ValueOrDefault, Is.EqualTo( 777 ) );
                Assert.That( value.ToString(), Is.EqualTo( "777" ) );
            }
            {
                var value = Option.From<int>( null );
                Assert.That( value.HasValue, Is.False );
                _ = Assert.Throws<InvalidOperationException>( () => _ = value.Value );
                Assert.That( value.ValueOrDefault, Is.Zero );
                Assert.That( value.ToString(), Is.EqualTo( "None" ) );
            }
        }

    }
}
