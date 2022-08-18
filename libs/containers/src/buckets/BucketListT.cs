//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class BucketList<T>
    {
        readonly Index<Bucket<T>> Data;

        uint Current;

        public BucketList(uint capacity)
        {
            Data = alloc<Bucket<T>>(capacity);
            Current = 0;
        }

        public BucketList(Bucket<T>[] src)
        {
            Data = src;
            Current = (uint)src.Length;
        }

        public uint Capacity
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref Bucket<T> this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref Bucket<T> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        [MethodImpl(Inline)]
        public BucketList<T> Include(params Bucket<T>[] src)
        {
            for(var i=0; Current<Capacity && i<src.Length; i++, Current++)
                this[Current] = skip(src,i);
            return this;
        }

        public string Format()
        {
            var dst = text.buffer();
            for(var i=0; i<Current; i++)
            {
                dst.Append(this[i].Format());
                dst.Append(Chars.NL);
            }
            return dst.Emit();
        }

    }
}