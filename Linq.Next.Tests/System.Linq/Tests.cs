namespace System.Linq {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    public class Tests {

        // Split
        [Test]
        public void Split() {
            // empty
            Split(
                Helper.Values<int>(),
                Helper.Predicate<int>( i => true ),
                Helper.Values<int[]>( Helper.Values<int>() )
                );
            // none
            Split(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int>( i => false ),
                Helper.Values<int[]>( Helper.Values<int>( 0, 1, 1, 2 ) )
                );
            // each
            Split(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int>( i => true ),
                Helper.Values<int[]>( Helper.Values<int>(), Helper.Values<int>(), Helper.Values<int>(), Helper.Values<int>(), Helper.Values<int>() )
                );
            // first
            Split(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int>( i => i is 0 ),
                Helper.Values<int[]>( Helper.Values<int>(), Helper.Values<int>( 1, 1, 2 ) )
                );
            // last
            Split(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int>( i => i is 2 ),
                Helper.Values<int[]>( Helper.Values<int>( 0, 1, 1 ), Helper.Values<int>() )
                );
            // center
            Split(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int>( i => i is 1 ),
                Helper.Values<int[]>( Helper.Values<int>( 0 ), Helper.Values<int>(), Helper.Values<int>( 2 ) )
                );
        }
        // Split/Before
        [Test]
        public void SplitBefore() {
            // empty
            SplitBefore(
                Helper.Values<int>(),
                Helper.Predicate<int>( i => true ),
                Helper.Values<int[]>( Helper.Values<int>() )
                );
            // none
            SplitBefore(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int>( i => false ),
                Helper.Values<int[]>( Helper.Values<int>( 0, 1, 1, 2 ) )
                );
            // each
            SplitBefore(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int>( i => true ),
                Helper.Values<int[]>( Helper.Values<int>(), Helper.Values<int>( 0 ), Helper.Values<int>( 1 ), Helper.Values<int>( 1 ), Helper.Values<int>( 2 ) )
                );
            // first
            SplitBefore(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int>( i => i is 0 ),
                Helper.Values<int[]>( Helper.Values<int>(), Helper.Values<int>( 0, 1, 1, 2 ) )
                );
            // last
            SplitBefore(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int>( i => i is 2 ),
                Helper.Values<int[]>( Helper.Values<int>( 0, 1, 1 ), Helper.Values<int>( 2 ) )
                );
            // center
            SplitBefore(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int>( i => i is 1 ),
                Helper.Values<int[]>( Helper.Values<int>( 0 ), Helper.Values<int>( 1 ), Helper.Values<int>( 1, 2 ) )
                );
        }
        // Split/After
        [Test]
        public void SplitAfter() {
            // empty
            SplitAfter(
                Helper.Values<int>(),
                Helper.Predicate<int>( i => true ),
                Helper.Values<int[]>( Helper.Values<int>() )
                );
            // none
            SplitAfter(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int>( i => false ),
                Helper.Values<int[]>( Helper.Values<int>( 0, 1, 1, 2 ) )
                );
            // each
            SplitAfter(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int>( i => true ),
                Helper.Values<int[]>( Helper.Values<int>( 0 ), Helper.Values<int>( 1 ), Helper.Values<int>( 1 ), Helper.Values<int>( 2 ), Helper.Values<int>() )
                );
            // first
            SplitAfter(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int>( i => i is 0 ),
                Helper.Values<int[]>( Helper.Values<int>( 0 ), Helper.Values<int>( 1, 1, 2 ) )
                );
            // last
            SplitAfter(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int>( i => i is 2 ),
                Helper.Values<int[]>( Helper.Values<int>( 0, 1, 1, 2 ), Helper.Values<int>() )
                );
            // center
            SplitAfter(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int>( i => i is 1 ),
                Helper.Values<int[]>( Helper.Values<int>( 0, 1 ), Helper.Values<int>( 1 ), Helper.Values<int>( 2 ) )
                );
        }

        // Slice
        [Test]
        public void Slice() {
            // empty
            Slice(
                Helper.Values<int>(),
                Helper.Predicate<int, IList<int>>( (i, slice) => true ),
                Helper.Values<int[]>()
                );
            // none
            Slice(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int, IList<int>>( (i, slice) => false ),
                Helper.Values<int[]>( Helper.Values<int>( 0 ), Helper.Values<int>( 1 ), Helper.Values<int>( 1 ), Helper.Values<int>( 2 ) )
                );
            // each
            Slice(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int, IList<int>>( (i, slice) => true ),
                Helper.Values<int[]>( Helper.Values<int>( 0, 1, 1, 2 ) )
                );
            // i == prev
            Slice(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int, IList<int>>( (i, slice) => i == slice.Last() ),
                Helper.Values<int[]>( Helper.Values<int>( 0 ), Helper.Values<int>( 1, 1 ), Helper.Values<int>( 2 ) )
                );
        }

        // Unflatten
        [Test]
        public void Unflatten() {
            // empty
            Unflatten(
                Helper.Values<int>(),
                Helper.Predicate<int>( i => true ),
                Helper.Values<(Option<int>, int[])>()
                );
            // none
            Unflatten(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int>( i => false ),
                Helper.Values<(Option<int>, int[])>( (default, Helper.Values<int>( 0, 1, 1, 2 )) )
            );
            // each
            Unflatten(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int>( i => true ),
                Helper.Values<(Option<int>, int[])>( (Option.Create( 0 ), Helper.Values<int>()), (Option.Create( 1 ), Helper.Values<int>()), (Option.Create( 1 ), Helper.Values<int>()), (Option.Create( 2 ), Helper.Values<int>()) )
            );
            // first
            Unflatten(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int>( i => i is 0 ),
                Helper.Values<(Option<int>, int[])>( (Option.Create( 0 ), Helper.Values<int>( 1, 1, 2 )) )
            );
            // last
            Unflatten(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int>( i => i is 2 ),
                Helper.Values<(Option<int>, int[])>( (default, Helper.Values<int>( 0, 1, 1 )), (Option.Create( 2 ), Helper.Values<int>()) )
            );
            // center
            Unflatten(
                Helper.Values<int>( 0, 1, 1, 2 ),
                Helper.Predicate<int>( i => i is 1 ),
                Helper.Values<(Option<int>, int[])>( (default, Helper.Values<int>( 0 )), (Option.Create( 1 ), Helper.Values<int>()), (Option.Create( 1 ), Helper.Values<int>( 2 )) )
            );
        }

        // With/Prev
        [Test]
        public static void WithPrev() {
            WithPrev(
                Helper.Values<int>(),
                Helper.Values<(int, Option<int>)>()
            );
            WithPrev(
                Helper.Values<int>( 0 ),
                Helper.Values<(int, Option<int>)>( (0, default) )
                );
            WithPrev(
                Helper.Values( 0, 1, 2 ),
                Helper.Values<(int, Option<int>)>( (0, default), (1, Option.Create( 0 )), (2, Option.Create( 1 )) )
                );
        }
        // With/Next
        [Test]
        public static void WithNext() {
            WithNext(
                Helper.Values<int>(),
                Helper.Values<(int, Option<int>)>()
                );
            WithNext(
                Helper.Values<int>( 0 ),
                Helper.Values<(int, Option<int>)>( (0, default) )
                );
            WithNext(
                Helper.Values( 0, 1, 2 ),
                Helper.Values<(int, Option<int>)>( (0, Option.Create( 1 )), (1, Option.Create( 2 )), (2, default) )
                );
        }
        // With/Prev-Next
        [Test]
        public static void WithPrevNext() {
            WithPrevNext(
                Helper.Values<int>(),
                Helper.Values<(int, Option<int>, Option<int>)>()
            );
            WithPrevNext(
                Helper.Values( 0 ),
                Helper.Values<(int, Option<int>, Option<int>)>( (0, default, default) )
                );
            WithPrevNext(
                Helper.Values( 0, 1, 2 ),
                Helper.Values<(int, Option<int>, Option<int>)>( (0, default, Option.Create( 1 )), (1, Option.Create( 0 ), Option.Create( 2 )), (2, Option.Create( 1 ), default) )
                );
        }

        // Tag/First
        [Test]
        public static void TagFirst() {
            TagFirst(
                Helper.Values<int>(),
                Helper.Values<(int, bool)>()
            );
            TagFirst(
                Helper.Values<int>( 0 ),
                Helper.Values<(int, bool)>( (0, true) )
            );
            TagFirst(
                Helper.Values( 0, 1, 2 ),
                Helper.Values<(int, bool)>( (0, true), (1, false), (2, false) )
            );
        }
        // Tag/Last
        [Test]
        public static void TagLast() {
            TagLast(
                Helper.Values<int>(),
                Helper.Values<(int, bool)>()
                );
            TagLast(
                Helper.Values<int>( 0 ),
                Helper.Values<(int, bool)>( (0, true) )
                );
            TagLast(
                Helper.Values<int>( 0, 1, 2 ),
                Helper.Values<(int, bool)>( (0, false), (1, false), (2, true) )
                );
        }
        // Tag/First-Last
        [Test]
        public static void TagFirstLast() {
            TagFirstLast(
                Helper.Values<int>(),
                Helper.Values<(int, bool, bool)>()
                );
            TagFirstLast(
                Helper.Values<int>( 0 ),
                Helper.Values<(int, bool, bool)>( (0, true, true) )
                );
            TagFirstLast(
                Helper.Values<int>( 0, 1, 2 ),
                Helper.Values<(int, bool, bool)>( (0, true, false), (1, false, false), (2, false, true) )
                );
        }

        // CompareTo
        [Test]
        public void CompareTo() {
            CompareTo(
                Helper.Values<int>( 0, 1, 2 ),
                Helper.Values<int>( 2, 3, 4 ),
                Helper.Values<int>( 3, 4 ),
                Helper.Values<int>( 0, 1 )
                );
        }

        // Helpers/Split
        private static void Split(int[] source, Func<int, bool> separatorPredicate, int[][] expected) {
            var actual = source.Split( separatorPredicate ).ToArray();
            Assert.That( actual, Is.EqualTo( expected ) );
        }
        private static void SplitBefore(int[] source, Func<int, bool> separatorPredicate, int[][] expected) {
            var actual = source.SplitBefore( separatorPredicate ).ToArray();
            Assert.That( actual, Is.EqualTo( expected ) );
        }
        private static void SplitAfter(int[] source, Func<int, bool> separatorPredicate, int[][] expected) {
            var actual = source.SplitAfter( separatorPredicate ).ToArray();
            Assert.That( actual, Is.EqualTo( expected ) );
        }
        // Helpers/Slice
        private static void Slice(int[] source, Func<int, IList<int>, bool> belongsToSlicePredicate, int[][] expected) {
            var actual = source.Slice( belongsToSlicePredicate ).ToArray();
            Assert.That( actual, Is.EqualTo( expected ) );
        }
        // Helpers/Unflatten
        private static void Unflatten(int[] source, Func<int, bool> keyPredicate, (Option<int> Key, int[] Values)[] expected) {
            var actual = source.Unflatten( keyPredicate ).ToArray();
            Assert.That( actual, Is.EqualTo( expected ) );
        }
        // Helpers/With
        private static void WithPrev(int[] source, (int, Option<int>)[] expected) {
            var actual = source.WithPrev().ToArray();
            Assert.That( actual, Is.EqualTo( expected ) );
        }
        private static void WithNext(int[] source, (int, Option<int>)[] expected) {
            var actual = source.WithNext().ToArray();
            Assert.That( actual, Is.EqualTo( expected ) );
        }
        private static void WithPrevNext(int[] source, (int, Option<int>, Option<int>)[] expected) {
            var actual = source.WithPrevNext().ToArray();
            Assert.That( actual, Is.EqualTo( expected ) );
        }
        // Helpers/Tag
        private static void TagFirst(int[] source, (int, bool)[] expected) {
            var actual = source.TagFirst().ToArray();
            Assert.That( actual, Is.EqualTo( expected ) );
        }
        private static void TagLast(int[] source, (int, bool)[] expected) {
            var actual = source.TagLast().ToArray();
            Assert.That( actual, Is.EqualTo( expected ) );
        }
        private static void TagFirstLast(int[] source, (int, bool, bool)[] expected) {
            var actual = source.TagFirstLast().ToArray();
            Assert.That( actual, Is.EqualTo( expected ) );
        }
        // Helpers/CompareTo
        private static void CompareTo(int[] source_actual, int[] source_expected, int[] expected_missing, int[] expected_extra) {
            source_actual.CompareTo( source_expected, out var actual_missing, out var actual_extra );
            Assert.That( actual_missing, Is.EqualTo( expected_missing ) );
            Assert.That( actual_extra, Is.EqualTo( expected_extra ) );
        }

    }
}
