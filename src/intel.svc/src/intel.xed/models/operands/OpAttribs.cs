//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedRules;
    
    partial class XedModels
    {
        public readonly struct OpAttribs : IFixedCells<OpAttrib>
        {
            readonly ByteBlock32 Data;

            public const byte Capacity = 32/3 - 1;

            public OpAttribs(OpAttrib[] src)
            {
                var storage = ByteBlock32.Empty;
                src.Sort();
                var dst = recover<OpAttrib>(storage.Bytes);
                var count = Demand.lt((uint)src.Length, Capacity);
                var k=z8;
                for(var i=0; i<count; i++)
                {
                    ref readonly var cell = ref skip(src,i);
                    if(cell.IsEmpty)
                        continue;

                    seek(dst,k++) = skip(src,i);
                }
                storage[31] = k;
                Data = storage;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Data[31];
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Count == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Count != 0;
            }

            public Span<OpAttrib> Edit
            {
                [MethodImpl(Inline)]
                get => recover<OpAttrib>(Data.Bytes);
            }

            public ReadOnlySpan<OpAttrib> View
            {
                [MethodImpl(Inline)]
                get => Edit;
            }

            public ByteBlock32 Storage
            {
                [MethodImpl(Inline)]
                get => Data;
            }

            public ref readonly OpAttrib this[int i]
            {
                [MethodImpl(Inline)]
                get => ref seek(Edit,i);
            }

            public ref readonly OpAttrib this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref seek(Edit,i);
            }

            public override string ToString()
                => Format();

            public string Format()
                => (this as IExpr).Format();

            public bool Search(OpAttribKind @class, out OpAttrib dst)
                => XedPatterns.first(this, @class, out dst);

            [MethodImpl(Inline)]
            public static implicit operator OpAttribs(OpAttrib[] src)
                => new OpAttribs(src);

            public static OpAttribs Empty => sys.empty<OpAttrib>();
        }
    }
}