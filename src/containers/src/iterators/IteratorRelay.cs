//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Iterators;

    public class IteratorRelay<T> : IIteratorRelay<IteratorRelay<T>,T>
    {
        readonly IMutableIterator<T> EditTarget;

        readonly IReadOnlyIterator<T> ViewTarget;

        readonly IOutputIterator<T> OutTarget;

        readonly IEnumerableTarget<T> EnumerableTarget;

        T _Current;

        public T Current
        {
            [MethodImpl(Inline)]
            get => _Current;
        }

        public IteratorRelay(IMutableIterator<T> target)
        {
            EditTarget = target;
            ViewTarget = default;
            OutTarget = default;
            _Current = default;
            EnumerableTarget = api.target(this);
        }

        public IteratorRelay(IReadOnlyIterator<T> target)
        {
            EditTarget = default;
            ViewTarget = target;
            OutTarget = default;
            _Current = default;
            EnumerableTarget = api.target(this);
        }

        public IteratorRelay(IOutputIterator<T> target)
        {
            EditTarget = default;
            ViewTarget = default;
            OutTarget = target;
            _Current = default;
            EnumerableTarget = api.target(this);
        }

        public IteratorRelay(EnumerableTarget<T> target)
        {
            EditTarget = default;
            ViewTarget = default;
            OutTarget = default;
            _Current = default;
            EnumerableTarget = api.target(this);
        }

        [MethodImpl(Inline)]
        void Enumerate(Span<T> src)
        {
            var iterator = new SpanIterator<T>(src);
            while(iterator.NextEdit(this)){ }
        }

        [MethodImpl(Inline)]
        internal void Edit(Span<T> src, IMutableIterator<T> dst)
        {
            var iterator = new SpanIterator<T>(src);
            while(iterator.NextEdit(this)){}
        }

        [MethodImpl(Inline)]
        internal void View(Span<T> src, IReadOnlyIterator<T> dst)
        {
            var iterator = new SpanIterator<T>(src);
            while(iterator.NextView(this)) { }
        }

        [MethodImpl(Inline)]
        internal void Output(Span<T> src, IOutputIterator<T> dst)
        {
            var iterator = new SpanIterator<T>(src);
            while(iterator.NextOutput(this)){}
        }

        [MethodImpl(Inline)]
        public void Edit(ref T dst, out bool success)
        {
            EditTarget.Edit(ref dst, out success);
            _Current = dst;
        }

        [MethodImpl(Inline)]
        public void Next(out T dst, out bool success)
        {
            OutTarget.Next(out dst, out success);
            _Current = dst;
        }

        [MethodImpl(Inline)]
        public void View(in T dst, out bool success)
        {
            ViewTarget.View(dst, out success);
            _Current = dst;
        }
    }
}