//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class LogicOps
    {
        public readonly struct Sop<T> : ISeqExpr<Product<T>>
            where T : IExpr
        {
            readonly Index<Product<T>> Data;

            [MethodImpl(Inline)]
            public Sop(Product<T>[] src)
                => Data = src;

            [MethodImpl(Inline)]
            public Sop(uint count)
                => Data = sys.alloc<Product<T>>(count);

            public ReadOnlySpan<Product<T>> Terms
            {
                [MethodImpl(Inline)]
                get => Data.View;
            }

            public ref Product<T> First
            {
                [MethodImpl(Inline)]
                get => ref Data.First;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public Product<T>[] Storage
            {
                [MethodImpl(Inline)]
                get => Data.Storage;
            }

            public ref Product<T> this[int index]
            {
                [MethodImpl(Inline)]
                get => ref Data[index];
            }

            public ref Product<T> this[uint index]
            {
                [MethodImpl(Inline)]
                get => ref Data[index];
            }

            public string Format()
                => OpFormatters.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Sop<T>(Product<T>[] src)
                => new Sop<T>(src);
        }
    }
}