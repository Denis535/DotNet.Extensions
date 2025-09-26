namespace System {
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Tests_00 {

        [Test]
        public void Test_00_Constructor() {
            {
                var value = (Option<int>) default;
                Assert.That( value.HasValue, Is.False );
                _ = Assert.Throws<InvalidOperationException>( () => _ = value.Value );
                Assert.That( value.ValueOrDefault, Is.Zero );

                Assert.That( value.ToString(), Is.EqualTo( "Nothing" ) );
                Assert.That( value.Equals( (Option<int>) default ), Is.True );
                Assert.That( value.Equals( 0 ), Is.False );
                Assert.That( value.GetHashCode(), Is.EqualTo( 0 ) );
            }
            {
                var value = new Option<int>();
                Assert.That( value.HasValue, Is.False );
                _ = Assert.Throws<InvalidOperationException>( () => _ = value.Value );
                Assert.That( value.ValueOrDefault, Is.Zero );

                Assert.That( value.ToString(), Is.EqualTo( "Nothing" ) );
                Assert.That( value.Equals( (Option<int>) default ), Is.True );
                Assert.That( value.Equals( 0 ), Is.False );
                Assert.That( value.GetHashCode(), Is.EqualTo( 0 ) );
            }
        }

        [Test]
        public void Test_01_Create() {
            {
                var value = Option.Create<int>();
                Assert.That( value.HasValue, Is.False );
                _ = Assert.Throws<InvalidOperationException>( () => _ = value.Value );
                Assert.That( value.ValueOrDefault, Is.Zero );

                Assert.That( value.ToString(), Is.EqualTo( "Nothing" ) );
                Assert.That( value.Equals( (Option<int>) default ), Is.True );
                Assert.That( value.Equals( 0 ), Is.False );
                Assert.That( value.GetHashCode(), Is.EqualTo( 0 ) );
            }
            {
                var value = Option.Create( 777 );
                Assert.That( value.HasValue, Is.True );
                Assert.That( value.Value, Is.EqualTo( 777 ) );
                Assert.That( value.ValueOrDefault, Is.EqualTo( 777 ) );

                Assert.That( value.ToString(), Is.EqualTo( "777" ) );
                Assert.That( value.Equals( Option.Create( 777 ) ), Is.True );
                Assert.That( value.Equals( 777 ), Is.True );
                Assert.That( value.GetHashCode(), Is.EqualTo( 777.GetHashCode() ) );
            }
            {
                var value = Option.Create<int>( null );
                Assert.That( value.HasValue, Is.False );
                _ = Assert.Throws<InvalidOperationException>( () => _ = value.Value );
                Assert.That( value.ValueOrDefault, Is.Zero );

                Assert.That( value.ToString(), Is.EqualTo( "Nothing" ) );
                Assert.That( value.Equals( (Option<int>) default ), Is.True );
                Assert.That( value.Equals( 0 ), Is.False );
                Assert.That( value.GetHashCode(), Is.EqualTo( 0 ) );
            }
            {
                var value = Option.Create( (int?) 777 );
                Assert.That( value.HasValue, Is.True );
                Assert.That( value.Value, Is.EqualTo( 777 ) );
                Assert.That( value.ValueOrDefault, Is.EqualTo( 777 ) );

                Assert.That( value.ToString(), Is.EqualTo( "777" ) );
                Assert.That( value.Equals( Option.Create( 777 ) ), Is.True );
                Assert.That( value.Equals( 777 ), Is.True );
                Assert.That( value.GetHashCode(), Is.EqualTo( 777.GetHashCode() ) );
            }
        }

    }
}
