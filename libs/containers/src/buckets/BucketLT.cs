//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class Bucket<L,T>
    {
        readonly Index<T> Data;

        public L Id {get;}

        uint Current;

        public Bucket(uint capacity, L id)
        {
            Data = alloc<T>(capacity);
            Id = id;
            Current = 0;
        }

        public Bucket(T[] data, L id)
        {
            Data = data;
            Id = id;
            Current = (uint)data.Length;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Current;
        }

        public uint Capacity
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref T this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public T[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        [MethodImpl(Inline)]
        public Bucket<L,T> Include(params T[] src)
        {
            for(var i=0; Current<Capacity && i<src.Length; i++, Current++)
                this[Current] = skip(src,i);
            return this;
        }

        public string Format(string sep = ", ")
        {
            var dst = text.buffer();
            dst.Append(Id.ToString());
            dst.Append(Chars.LParen);
            for(var i=0; i<Current; i++)
            {
                if(i != 0)
                    dst.Append(sep);
                dst.Append(this[i].ToString());
            }
            dst.Append(Chars.RParen);
            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}