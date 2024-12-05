namespace System.Linq {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    public class Tests {

        // Split
        [Test]
        public void Test_00_Split() {
            {
                var actual = IntArray().Split( i => true ).ToArray();
                var expected = IntArray2D( IntArray() );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).Split( i => false ).ToArray();
                var expected = IntArray2D( IntArray( 0, 1, 1, 2 ) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).Split( i => true ).ToArray();
                var expected = IntArray2D( IntArray(), IntArray(), IntArray(), IntArray(), IntArray() );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).Split( i => i == 0 ).ToArray();
                var expected = IntArray2D( IntArray(), IntArray( 1, 1, 2 ) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).Split( i => i == 2 ).ToArray();
                var expected = IntArray2D( IntArray( 0, 1, 1 ), IntArray() );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).Split( i => i == 1 ).ToArray();
                var expected = IntArray2D( IntArray( 0 ), IntArray(), IntArray( 2 ) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
        }
        // Split/Before
        [Test]
        public void Test_00_SplitBefore() {
            {
                var actual = IntArray().SplitBefore( i => true ).ToArray();
                var expected = IntArray2D( IntArray() );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).SplitBefore( i => false ).ToArray();
                var expected = IntArray2D( IntArray( 0, 1, 1, 2 ) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).SplitBefore( i => true ).ToArray();
                var expected = IntArray2D( IntArray(), IntArray( 0 ), IntArray( 1 ), IntArray( 1 ), IntArray( 2 ) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).SplitBefore( i => i == 0 ).ToArray();
                var expected = IntArray2D( IntArray(), IntArray( 0, 1, 1, 2 ) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).SplitBefore( i => i == 2 ).ToArray();
                var expected = IntArray2D( IntArray( 0, 1, 1 ), IntArray( 2 ) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).SplitBefore( i => i == 1 ).ToArray();
                var expected = IntArray2D( IntArray( 0 ), IntArray( 1 ), IntArray( 1, 2 ) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
        }
        // Split/After
        [Test]
        public void Test_00_SplitAfter() {
            {
                var actual = IntArray().SplitAfter( i => true ).ToArray();
                var expected = IntArray2D( IntArray() );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).SplitAfter( i => false ).ToArray();
                var expected = IntArray2D( IntArray( 0, 1, 1, 2 ) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).SplitAfter( i => true ).ToArray();
                var expected = IntArray2D( IntArray( 0 ), IntArray( 1 ), IntArray( 1 ), IntArray( 2 ), IntArray() );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).SplitAfter( i => i == 0 ).ToArray();
                var expected = IntArray2D( IntArray( 0 ), IntArray( 1, 1, 2 ) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).SplitAfter( i => i == 2 ).ToArray();
                var expected = IntArray2D( IntArray( 0, 1, 1, 2 ), IntArray() );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).SplitAfter( i => i == 1 ).ToArray();
                var expected = IntArray2D( IntArray( 0, 1 ), IntArray( 1 ), IntArray( 2 ) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
        }

        // Slice
        [Test]
        public void Test_01_Slice() {
            {
                var actual = IntArray().Slice( (i, slice) => true ).ToArray();
                var expected = IntArray2D();
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).Slice( (i, slice) => false ).ToArray();
                var expected = IntArray2D( IntArray( 0 ), IntArray( 1 ), IntArray( 1 ), IntArray( 2 ) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).Slice( (i, slice) => true ).ToArray();
                var expected = IntArray2D( IntArray( 0, 1, 1, 2 ) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).Slice( (i, slice) => i == slice.Last() ).ToArray();
                var expected = IntArray2D( IntArray( 0 ), IntArray( 1, 1 ), IntArray( 2 ) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
        }

        // Unflatten
        [Test]
        public void Test_02_Unflatten() {
            {
                var actual = IntArray().Unflatten( i => true ).ToArray();
                var expected = Array<(Option<int>, int[])>();
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).Unflatten( i => false ).ToArray();
                var expected = Array<(Option<int>, int[])>( (default, Array<int>( 0, 1, 1, 2 )) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).Unflatten( i => true ).ToArray();
                var expected = Array<(Option<int>, int[])>( (Option.Create( 0 ), Array<int>()), (Option.Create( 1 ), Array<int>()), (Option.Create( 1 ), Array<int>()), (Option.Create( 2 ), Array<int>()) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).Unflatten( i => i == 0 ).ToArray();
                var expected = Array<(Option<int>, int[])>( (Option.Create( 0 ), Array<int>( 1, 1, 2 )) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).Unflatten( i => i == 2 ).ToArray();
                var expected = Array<(Option<int>, int[])>( (default, Array<int>( 0, 1, 1 )), (Option.Create( 2 ), Array<int>()) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 1, 2 ).Unflatten( i => i == 1 ).ToArray();
                var expected = Array<(Option<int>, int[])>( (default, Array<int>( 0 )), (Option.Create( 1 ), Array<int>()), (Option.Create( 1 ), Array<int>( 2 )) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
        }

        // With/Prev
        [Test]
        public static void Test_03_WithPrev() {
            {
                var actual = IntArray().WithPrev().ToArray();
                var expected = Array<(int, Option<int>)>();
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0 ).WithPrev().ToArray();
                var expected = Array<(int, Option<int>)>( (0, default) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 2 ).WithPrev().ToArray();
                var expected = Array<(int, Option<int>)>( (0, default), (1, Option.Create( 0 )), (2, Option.Create( 1 )) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
        }
        // With/Next
        [Test]
        public static void Test_03_WithNext() {
            {
                var actual = IntArray().WithNext().ToArray();
                var expected = Array<(int, Option<int>)>();
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0 ).WithNext().ToArray();
                var expected = Array<(int, Option<int>)>( (0, default) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 2 ).WithNext().ToArray();
                var expected = Array<(int, Option<int>)>( (0, Option.Create( 1 )), (1, Option.Create( 2 )), (2, default) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
        }
        // With/Prev-Next
        [Test]
        public static void Test_03_WithPrevNext() {
            {
                var actual = IntArray().WithPrevNext().ToArray();
                var expected = Array<(int, Option<int>, Option<int>)>();
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0 ).WithPrevNext().ToArray();
                var expected = Array<(int, Option<int>, Option<int>)>( (0, default, default) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 2 ).WithPrevNext().ToArray();
                var expected = Array<(int, Option<int>, Option<int>)>( (0, default, Option.Create( 1 )), (1, Option.Create( 0 ), Option.Create( 2 )), (2, Option.Create( 1 ), default) );
                Assert.That( actual, Is.EqualTo( expected ) );
            }
        }

        // Tag/First
        [Test]
        public static void Test_04_TagFirst() {
            {
                var actual = IntArray().TagFirst().ToArray();
                var expected = Array<(int, bool)>().ToArray();
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0 ).TagFirst().ToArray();
                var expected = Array<(int, bool)>( (0, true) ).ToArray();
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 2 ).TagFirst().ToArray();
                var expected = Array<(int, bool)>( (0, true), (1, false), (2, false) ).ToArray();
                Assert.That( actual, Is.EqualTo( expected ) );
            }
        }
        // Tag/Last
        [Test]
        public static void Test_04_TagLast() {
            {
                var actual = IntArray().TagLast().ToArray();
                var expected = Array<(int, bool)>().ToArray();
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0 ).TagLast().ToArray();
                var expected = Array<(int, bool)>( (0, true) ).ToArray();
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 2 ).TagLast().ToArray();
                var expected = Array<(int, bool)>( (0, false), (1, false), (2, true) ).ToArray();
                Assert.That( actual, Is.EqualTo( expected ) );
            }
        }
        // Tag/First-Last
        [Test]
        public static void Test_04_TagFirstLast() {
            {
                var actual = IntArray().TagFirstLast().ToArray();
                var expected = Array<(int, bool, bool)>().ToArray();
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0 ).TagFirstLast().ToArray();
                var expected = Array<(int, bool, bool)>( (0, true, true) ).ToArray();
                Assert.That( actual, Is.EqualTo( expected ) );
            }
            {
                var actual = IntArray( 0, 1, 2 ).TagFirstLast().ToArray();
                var expected = Array<(int, bool, bool)>( (0, true, false), (1, false, false), (2, false, true) ).ToArray();
                Assert.That( actual, Is.EqualTo( expected ) );
            }
        }

        // CompareTo
        [Test]
        public void Test_05_CompareTo() {
            IntArray( 0, 1, 2 ).CompareTo( IntArray( 2, 3, 4 ), out var actual_missing, out var actual_extra );
            Assert.That( actual_missing, Is.EqualTo( IntArray( 3, 4 ) ) );
            Assert.That( actual_extra, Is.EqualTo( IntArray( 0, 1 ) ) );
        }

        // Helpers
        private static int[] IntArray(params int[] array) {
            return array;
        }
        private static int[][] IntArray2D(params int[][] array) {
            return array;
        }
        public static T[] Array<T>(params T[] values) {
            return values;
        }

    }
}
