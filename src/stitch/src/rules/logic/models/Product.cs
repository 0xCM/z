//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class LogicOps
    {
        /// <summary>
        /// Defines a conunction of expressions
        /// </summary>
        public readonly struct Product : ISeqExpr<IExpr>
        {
            readonly Index<IExpr> Data;

            [MethodImpl(Inline)]
            public Product(IExpr[] src)
                => Data = src;

            [MethodImpl(Inline)]
            public Product(uint count)
                => Data = sys.alloc<IExpr>(count);

            public ReadOnlySpan<IExpr> Terms
            {
                [MethodImpl(Inline)]
                get => Data.View;
            }

            public ref IExpr First
            {
                [MethodImpl(Inline)]
                get => ref Data.First;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public IExpr[] Storage
            {
                [MethodImpl(Inline)]
                get => Data.Storage;
            }

            public ref IExpr this[int index]
            {
                [MethodImpl(Inline)]
                get => ref Data[index];
            }

            public ref IExpr this[uint index]
            {
                [MethodImpl(Inline)]
                get => ref Data[index];
            }

            public string Format()
                => format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Product(IExpr[] src)
                => new Product(src);
        }
    }
}