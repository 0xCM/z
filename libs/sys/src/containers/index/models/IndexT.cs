//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct Index<T> : IIndex<T>
    {
        readonly T[] Data;

        [MethodImpl(Inline)]
        public Index(T[] content)
            => Data = content;

        public T[] Storage
        {
            [MethodImpl(Inline)]
            get => Data ?? empty<T>();
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Storage.Length;
        }

        public Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public Span<T> Slice(uint offset)
            => slice(Edit, offset);

        [MethodImpl(Inline)]
        public Span<T> Slice(uint offset, uint length)
            => slice(Edit, offset, length);

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Length == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Length != 0;
        }

        public ref T this[long i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Data, i);
        }

        public ref T this[ulong i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Data,i);
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Length;
        }

        public ref T First
        {
            [MethodImpl(Inline)]
            get => ref first(Data);
        }

        public ref T Last
        {
            [MethodImpl(Inline)]
            get => ref last(Data);
        }

        public uint Size
        {
            [MethodImpl(Inline)]
            get => size<T>()*Count;
        }

        [MethodImpl(Inline)]
        public bool Any(Func<T,bool> predicate)
        {
            var count = Count;
            var view = View;
            for(var i=0; i<count; i++)
                if(predicate(skip(Data,i)))
                    return true;
            return false;
        }

        [MethodImpl(Inline)]
        public Index<T> Clear()
            => new Index<T>(clear(Data));

        public string Format()
            => IsNonEmpty ? string.Join(Chars.Comma, Data) : EmptyString;

        public override string ToString()
            => Format();

        public Index<T> Reverse()
            => new Index<T>(reverse(Data));

        public Index<T> Sort(IComparer<T> comparer)
            => new Index<T>(sort(Data,comparer));

        [MethodImpl(Inline)]
        public bool Search(Func<T,bool> predicate, out T found)
            => first(this, predicate, out found);

        public Index<Y> Cast<Y>()
            => new Index<Y>(Data.Select(x => cast<Y>(x)));

        public Index<Y> Select<Y>(Func<T,Y> selector)
             => map(Data, selector);

        public Index<Z> SelectMany<Y,Z>(Func<T,Index<Y>> lift, Func<T,Y,Z> project)
             => Index.map(Data, lift, project);

        public Index<Y> SelectMany<Y>(Func<T,Index<Y>> lift)
             => Index.map(Data, lift);

        public Index<T> Where(Func<T,bool> predicate)
            => where(Data, predicate).ToArray();

        public Index<T> Distinct()
            => new Index<T>(Data.Distinct());

        public T Single()
            => Count == 1 ? First : throw new Exception("More than one - or perhaps none");

        [MethodImpl(Inline)]
        public T[] ToArray()
            => Data;

        [MethodImpl(Inline)]
        public Span<T> ToSpan()
            => Data;

        /// <summary>
        /// Allocates and populates a copy of the underlying storage
        /// </summary>
        public Index<T> Replicate()
        {
            var dst = alloc<T>(Count);
            Array.Copy(Storage,dst,Count);
            return dst;
        }

        [MethodImpl(Inline)]
        public static implicit operator Span<T>(Index<T> src)
            => src.Edit;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<T>(Index<T> src)
            => src.View;

        [MethodImpl(Inline)]
        public static implicit operator T[](Index<T> src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator Index<T>(T[] src)
            => new Index<T>(src);

        [MethodImpl(Inline)]
        public static Index<T> operator +(Index<T> a, Index<T> b)
            => a.Append(b);

        public static Index<T> Empty
        {
           [MethodImpl(Inline)]
           get => new Index<T>(empty<T>());
        }
    }    
}