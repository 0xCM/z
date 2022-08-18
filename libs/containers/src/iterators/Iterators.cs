//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct Iterators
    {
        const NumericKind Closure = UnsignedInts;

        [Op, Closures(Closure)]
        public static IteratorRelay<T> relay<T>(IOutputIterator<T> dst)
            => new IteratorRelay<T>(dst);

        [Op, Closures(Closure)]
        public static IteratorRelay<T> relay<T>(IReadOnlyIterator<T> dst)
            => new IteratorRelay<T>(dst);

        [Op, Closures(Closure)]
        public static IteratorRelay<T> relay<T>(IMutableIterator<T> dst)
            => new IteratorRelay<T>(dst);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ViewTrigger<T> trigger<T>(Receiver<T> receiver)
            => new ViewTrigger<T>(receiver);

        [Op, Closures(Closure)]
        public static OutputReceiver<T> receiver<T>(ViewTrigger<T> trigger)
            => OutputReceiver<T>.create(trigger);

        [Op, Closures(Closure)]
        public static EnumerableTarget<T> target<T>(IteratorRelay<T> relay)
            => new EnumerableTarget<T>(relay);
    }
}