namespace System.Collections.Generic {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;

    public class Tests_Enumerator {

        // Take
        [Test]
        public void Take() {
            using var source = new int[] { 0, 1, 2 }.AsEnumerable().GetEnumerator();
            Assert.That( source.Take(), Is.EqualTo( Option.Create( 0 ) ) );
            Assert.That( source.Take(), Is.EqualTo( Option.Create( 1 ) ) );
            Assert.That( source.Take(), Is.EqualTo( Option.Create( 2 ) ) );
            Assert.That( source.Take(), Is.EqualTo( Option.Create<int>( null ) ) );
        }

    }
}
