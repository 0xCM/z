//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public abstract class Seq<S,T> : ReadOnlySeq<S,T>, ISeq<S,T>
        where S : Seq<S,T>, new()
    {
        public Seq()
        {

        }

        [MethodImpl(Inline)]
        protected Seq(T[] src)
            : base(src)
        {

        }
        
        public static S alloc(uint count)
        {
            var dst = new S();
            return dst.Alloc(count);
        }

        public S Alloc(uint count)
        {
            var dst = new S();            
            var data = sys.alloc<T>(count);
            Data = data;
            return dst;
        }

        public virtual Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public new ref T this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public new ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public new ref T First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public Span<T> Slice(int offset)
            => sys.slice(Data.Edit,offset);

        public Span<T> Slice(int offset, int length)
            => sys.slice(Data.Edit, offset, length);

        public Span<T> Slice(uint offset)
            => sys.slice(Data.Edit,offset);

        public Span<T> Slice(uint offset, uint length)
            => sys.slice(Data.Edit, offset, length);

        public Seq<T> Reverse()
            => new Seq<T>(Data.Reverse());

        public new Span<T>.Enumerator GetEnumerator()
            => Edit.GetEnumerator();

        public new Seq<Y> Select<Y>(Func<T,Y> f)
            => Seq.select(View, f);

        public Seq<Z> SelectMany<Y,Z>(Func<T,Seq<Y>> lift, Func<T,Y,Z> project)
             => Seq.map(Edit, lift, project);

        public Seq<Y> SelectMany<Y>(Func<T,Seq<Y>> lift)
             => Seq.map(Edit, lift);

        public new Seq<T> Where(Func<T,bool> predicate)
            => Seq.where(Edit, predicate);
    }
}