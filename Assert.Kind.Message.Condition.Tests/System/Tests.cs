namespace System {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class Tests {

        [Test]
        public void Test_00_Assertions() {
            // Assert.Argument
            _ = NUnit.Framework.Assert.Catch<ArgumentException>( () => Assert.Argument.Message( $"ArgumentException" ).Valid( false ) );
            _ = NUnit.Framework.Assert.Catch<ArgumentNullException>( () => Assert.Argument.Message( $"ArgumentNullException" ).NotNull( false ) );
            _ = NUnit.Framework.Assert.Catch<ArgumentOutOfRangeException>( () => Assert.Argument.Message( $"ArgumentOutOfRangeException" ).InRange( false ) );
            // Assert.Operation
            _ = NUnit.Framework.Assert.Catch<InvalidOperationException>( () => Assert.Operation.Message( $"InvalidOperationException" ).Valid( false ) );
            _ = NUnit.Framework.Assert.Catch<ObjectNotReadyException>( () => Assert.Operation.Message( $"ObjectNotReadyException" ).Ready( false ) );
            _ = NUnit.Framework.Assert.Catch<ObjectDisposedException>( () => Assert.Operation.Message( $"ObjectDisposedException" ).NotDisposed( false ) );
        }

        [Test]
        public void Test_01_Exceptions() {
            // Exceptions.Argument
            _ = NUnit.Framework.Assert.Catch<ArgumentException>( () => throw Exceptions.Argument.ArgumentException( $"ArgumentException" ) );
            _ = NUnit.Framework.Assert.Catch<ArgumentNullException>( () => throw Exceptions.Argument.ArgumentNullException( $"ArgumentNullException" ) );
            _ = NUnit.Framework.Assert.Catch<ArgumentOutOfRangeException>( () => throw Exceptions.Argument.ArgumentOutOfRangeException( $"ArgumentOutOfRangeException" ) );
            // Exceptions.Operation
            _ = NUnit.Framework.Assert.Catch<InvalidOperationException>( () => throw Exceptions.Operation.InvalidOperationException( $"InvalidOperationException" ) );
            _ = NUnit.Framework.Assert.Catch<ObjectNotReadyException>( () => throw Exceptions.Operation.ObjectNotReadyException( $"ObjectNotReadyException" ) );
            _ = NUnit.Framework.Assert.Catch<ObjectDisposedException>( () => throw Exceptions.Operation.ObjectDisposedException( $"ObjectDisposedException" ) );
            // Exceptions.Internal
            _ = NUnit.Framework.Assert.Catch<Exception>( () => throw Exceptions.Internal.Exception( $"Exception" ) );
            _ = NUnit.Framework.Assert.Catch<NullReferenceException>( () => throw Exceptions.Internal.NullReference( $"NullReferenceException" ) );
            _ = NUnit.Framework.Assert.Catch<NotSupportedException>( () => throw Exceptions.Internal.NotSupported( $"NotSupportedException" ) );
            _ = NUnit.Framework.Assert.Catch<NotImplementedException>( () => throw Exceptions.Internal.NotImplemented( $"NotImplementedException" ) );
        }

        [Test]
        public void Test_02_GetMessageString() {
            TestContext.Out.WriteLine( Exceptions.Factory.GetMessageStringDelegate( $"Value: {null}" ) );
            TestContext.Out.WriteLine( Exceptions.Factory.GetMessageStringDelegate( $"Value: {"777"}" ) );
            TestContext.Out.WriteLine( Exceptions.Factory.GetMessageStringDelegate( $"Value: {777}" ) );
            TestContext.Out.WriteLine( Exceptions.Factory.GetMessageStringDelegate( $"Values: {new object?[] { null, 777, "777" }}" ) );
        }

    }
}
