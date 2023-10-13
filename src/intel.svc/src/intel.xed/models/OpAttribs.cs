//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class XedModels
{
    public readonly struct OpAttribs
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
            [MethodImpl(Inline), UnscopedRef]
            get => recover<OpAttrib>(sys.bytes(Data));
        }

        public ReadOnlySpan<OpAttrib> View
        {
            [MethodImpl(Inline), UnscopedRef]
            get => Edit;
        }

        public ByteBlock32 Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref readonly OpAttrib this[int i]
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref seek(Edit,i);
        }

        public ref readonly OpAttrib this[uint i]
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref seek(Edit,i);
        }

        public string Format()
        {
            var dst = text.emitter();
            if(Count != 0)
            {
                dst.Append(Chars.LBrace);
                for(var i=0; i<Count; i++)
                {
                    if(i != 0)
                        dst.Append(", ");
                    dst.Append($"{this[i].Kind}:{this[i].Format()}");
                }
                dst.Append(Chars.RBrace);
            }
            return dst.Emit();
        }

        public override string ToString()
            => Format();
            
        public bool Search(OpAttribKind @class, out OpAttrib dst)
            => XedPatterns.first(this, @class, out dst);

        [MethodImpl(Inline)]
        public static implicit operator OpAttribs(OpAttrib[] src)
            => new (src);

        public static OpAttribs Empty => sys.empty<OpAttrib>();
    }
}
