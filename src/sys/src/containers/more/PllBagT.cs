//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class PllBag<T> : IReceiver<T>
    {
        readonly ConcurrentBag<T> Data;

        public PllBag()
        {
            Data = new();
        }


        public PllBag(ReadOnlySpan<T> src)
            : this()
        {
            Add(src);
        }

        public void Deposit(in T src)
        {
            Data.Add(src);
        }

        public void Add(ReadOnlySpan<T> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                Data.Add(skip(src,i));
        }

        public Index<T> Emit()
        {
            var data = Data.ToArray();
            Data.Clear();
            return data;
        }


    }
}