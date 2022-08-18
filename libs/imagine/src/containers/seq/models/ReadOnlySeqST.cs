//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public abstract class ReadOnlySeq<S,T> : IReadOnlySeq<T>, IEnumerable<T>
        where S : ReadOnlySeq<S,T>, new()
    {
        public static S create(params T[] src)
        {
            var dst = new S();
            dst.Data = src;
            return dst;
        }

        protected Index<T> Data;

        [MethodImpl(Inline)]
        protected ReadOnlySeq(T[] src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        protected ReadOnlySeq()
        {
            Data = sys.empty<T>();
        }

        public T[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public virtual uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public virtual int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public virtual bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public virtual bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Algs.hash(View);
        }


        public virtual ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ref readonly T First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ref readonly T this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref readonly T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref readonly T Last
        {
            [MethodImpl(Inline)]
            get => ref Data.Last;
        }

        public ReadOnlySpan<T>.Enumerator GetEnumerator()
            => View.GetEnumerator();

        public ReadOnlySeq<Y> Select<Y>(Func<T,Y> f)
            => Seq.select(View, f);

        public ReadOnlySeq<Z> SelectMany<Y,Z>(Func<T,ReadOnlySeq<Y>> lift, Func<T,Y,Z> project)
             => Seq.map(View, lift, project);

        public ReadOnlySeq<Y> SelectMany<Y>(Func<T,ReadOnlySeq<Y>> lift)
             => Seq.map(View, lift);

        public ReadOnlySeq<T> Where(Func<T,bool> predicate)
            => Seq.where(View, predicate);

        public S Distinct()
            => create(Data.Distinct());

        public void Iter(Action<T> f)
            => Algs.iter(View, f);

        [MethodImpl(Inline)]
        public Seq<T> Unwrap()
            => Data;

        [MethodImpl(Inline)]
        public T[] ToArray()
            => Data;

        public virtual string Delimiter => Eol;

        public virtual Fence<char>? Fence => (Chars.LBrace,Chars.RBrace);

        public virtual int CellPad => 0;

        public virtual string Format()
            => Seq.format(Data.Storage, Delimiter);

        public override string ToString()
            => Format();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => (Data as IIndex<T>).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => (Data as IIndex<T>).GetEnumerator();


        public Seq<Y> Cast<Y>()
            => Seq.cast<T,Y>(Storage);
 
        
        public static S Empty => new ();
    }

    partial class XTend
    {

        public static Seq<T> Sort<T>(this Seq<T> src)
            where T : IComparable<T>
                => src.Storage.Sort();

        public static ReadOnlySeq<T> Sort<T>(this ReadOnlySeq<T> src)
            where T : IComparable<T>                
                => src.Storage.Sort();
    }
}